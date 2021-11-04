using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBotCCAffect : MonoBehaviour
{
    [SerializeField]
    GameObject model;
    [SerializeField]
    GameObject bot;

    private bool isStunned;
    private bool isKnockedUp;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void stunBot(float time)
    {
        while(Time.time < time)
        {
            Debug.Log("stunned");
        }
    }


}
