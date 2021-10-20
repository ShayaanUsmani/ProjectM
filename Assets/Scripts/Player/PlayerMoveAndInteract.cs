using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMoveAndInteract : MonoBehaviour
{
    Camera cam;
    public NavMeshAgent player;
    private int rayCastDist = 20;
    public int movementMouseButton = 1;
    private GameObject target;

    private string enemyTag = "EnemyBot";
    private bool canMove = true;


    // player stats
    private int autoDmg = 70;
    private float autoRange = 3.5f;
    private float attackSpeed = 1f;
    private float nextAutoTime = 0f;



    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
        {
            player = GameObject.Find("Player").GetComponent<NavMeshAgent>();
        }
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(movementMouseButton))
        {
            if (canMove)
            {
                player.SetDestination(ClickPoint());
            }

            
        }
        if (target != null && target.CompareTag(enemyTag))
        {
            ClickedEnemyBot();
        }

    }


    private void ClickedEnemyBot()
    {
        EnemyBotHealthManager enemyBotHealthManager = target.GetComponent<EnemyBotHealthManager>(); // looks nasty, maybe assign
                                                                                                    // allocated amount at start
                                                                                                    // to not have to make so many
        if(Mathf.Abs(player.transform.position.z - target.transform.position.z) <= autoRange)
        {
            //canMove = false;
            if (Time.time > nextAutoTime)
            {
                enemyBotHealthManager.takeDamage(autoDmg);
                nextAutoTime = Time.time + 1f/attackSpeed;
            }
        }
    }

    // Returns the point on the ground you clicked at
    private Vector3 ClickPoint()
    {
        RaycastHit hit;
        Vector3 mousePos3D = Input.mousePosition;
        Physics.Raycast(cam.ScreenPointToRay(mousePos3D), out hit, rayCastDist);
        Collider hitCollider = hit.collider;
        if (hitCollider != null)
        {
            target = hitCollider.gameObject; // set target to the object with a trigger player clicked on
                                                                         // as we will first get the hitbox object, we need to get the
                                                                         // parent of the hitbox
            if (hitCollider.isTrigger)
            {
                target = target.transform.parent.gameObject;
            }
        }
        else
        {
            canMove = true;
        }
        return hit.point;

    }
}
