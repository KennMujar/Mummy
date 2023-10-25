using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoleController : MonoBehaviour
{
    
    private bool isColldingLeftSlide = false;
    private bool isCollidngRightSlide = false;
    
    public bool IsSliding()
    {
        return isCollidngRightSlide && isColldingLeftSlide;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Pole 1")
        {
            isColldingLeftSlide = true;
        }
        if (collision.gameObject.tag == "Pole 2")
        {
            isCollidngRightSlide = true;
        }
       
    }


    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Pole 1")
        {
            isColldingLeftSlide = false;
        }
        if (collision.gameObject.tag == "Pole 2")
        {
            isCollidngRightSlide = false;
        }
       
    }
}
