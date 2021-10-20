using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper : MonoBehaviour   
{
    public static T FindComponentInChildrenWithTag<T>(GameObject parent, string tag)where T:Component
    {
        foreach(Transform child in parent.transform)
        {
            if(child.tag == tag)
            {
                return child.GetComponent<T>();
            }
        }
        return null;
    }
}
