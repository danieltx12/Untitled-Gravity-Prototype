using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Rigidbody Ball;
    public float speed;


    private void Update()
    {
        
        if (Input.GetButtonDown("Fire1"))
        {
            Rigidbody clone;
            clone = Instantiate(Ball, transform.position, transform.rotation);
            clone.velocity = transform.TransformDirection(Vector3.forward * speed);
            
        }
    }
}
