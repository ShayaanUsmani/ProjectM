using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    Camera cam;
    public NavMeshAgent player;
    private int rayCastDist = 20;
    public int movementMouseButton = 1;

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
            player.SetDestination(ClickPoint());
        }
    }

    // Returns the point on the ground you clicked at
    private Vector3 ClickPoint()
    {
        RaycastHit hit;
        Vector3 mousePos3D = Input.mousePosition;
        Physics.Raycast(cam.ScreenPointToRay(mousePos3D), out hit, rayCastDist);
        return hit.point;
    }
}
