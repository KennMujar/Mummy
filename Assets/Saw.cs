using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    public GameObject pole;

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Pole")
        {
            pole.transform.localScale -= new Vector3(0f, 0.5f,0f);
            Debug.Log(collision.gameObject.name);
        }
    }
}
