using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    public Vector3 playerPos;
    public Vector3 initOffset;
    public GameObject player;
    public KeyCode recenterKey = KeyCode.Space;
    public int cameraMoveSpeedMouse = 10;

    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
        {
            player = GameObject.Find("Player");
        }

        initOffset = gameObject.transform.position - playerPos;
    }

    // Update is called once per frame
    void Update()
    {
        RecenterOnInput();
        MouseOnEdge();
    }

    void RecenterOnInput()
    {
        playerPos = player.transform.position;
        if (Input.GetKey(recenterKey))
        {
            gameObject.transform.position = playerPos + initOffset;
        }
    }

    void MouseOnEdge()
    {
        if (Input.mousePosition.y >= Screen.height * 0.95)
        {
            gameObject.transform.Translate(Vector3.forward * cameraMoveSpeedMouse, Space.World);
        }
    }
}
