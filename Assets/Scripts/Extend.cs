using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extend : MonoBehaviour
{
    public GameObject pole;
    
    
    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "ExtendShort":
                pole.transform.localScale += new Vector3(0f, 0.5f, 0f);
                break;
            case "ExtendLong":
                pole.transform.localScale += new Vector3(0f, 1f, 0f);
                break;
        }
        
    }
}
