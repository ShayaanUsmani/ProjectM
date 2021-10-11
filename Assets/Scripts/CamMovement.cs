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

    // Recenter the camera onto the player when holding down the recenter key
    void RecenterOnInput()
    {
        playerPos = player.transform.position;
        if (Input.GetKey(recenterKey))
        {
            gameObject.transform.position = playerPos + initOffset;
        }
    }

    // Adjust the camera when mouse cursor is on edge of the screen
    void MouseOnEdge()
    {
        if (Input.GetKey(recenterKey))
        {
            return;
        }
        if (Input.mousePosition.y >= Screen.height * 0.95)
        {
            gameObject.transform.Translate(Vector3.forward * cameraMoveSpeedMouse * Time.deltaTime, Space.World);
        }
        else if (Input.mousePosition.y <= Screen.height * 0.05)
        {
            gameObject.transform.Translate(Vector3.back * cameraMoveSpeedMouse * Time.deltaTime, Space.World);
        }
        if (Input.mousePosition.x >= Screen.width * 0.95)
        {
            gameObject.transform.Translate(Vector3.right * cameraMoveSpeedMouse * Time.deltaTime, Space.World);
        }
        else if (Input.mousePosition.x <= Screen.width * 0.05)
        {
            gameObject.transform.Translate(Vector3.left * cameraMoveSpeedMouse * Time.deltaTime, Space.World);
        }
    }
}
