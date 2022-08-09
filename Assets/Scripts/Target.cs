using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    bool isHit = false;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 8 && !isHit)
        {
            isHit = !isHit;
            //DO THING
            Debug.Log("HIT");
        }
    }
}
