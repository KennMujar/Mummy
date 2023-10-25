using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(15f, 15f, 10f) * 5f * Time.deltaTime); 
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
