using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthGolemAbilities : MonoBehaviour
{
    public KeyCode qKey = KeyCode.Q;
    public KeyCode wKey = KeyCode.W;
    public KeyCode eKey = KeyCode.E;
    public KeyCode rKey = KeyCode.R;


    [SerializeField]
    private GameObject earthTornadoFirstRange;
    [SerializeField]
    private GameObject earthTornadoSecondRange;

    private float earthTornadoKnockTime = 0.6f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(qKey))
        {
            EarthTornado();
        }
    }


    private void EarthTornado()
    {

    }
}
