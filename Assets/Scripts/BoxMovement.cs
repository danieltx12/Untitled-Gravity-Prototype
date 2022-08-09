using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMovement : MonoBehaviour
{

    public float maxDistance;
    bool holding = false;
    Transform currentHold;
    Rigidbody holdRb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.green);
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!holding)
            {
               
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, maxDistance, 9))
                {
                    Debug.Log(hit);
                    hit.transform.parent = this.transform;
                    hit.rigidbody.useGravity = false;
                    currentHold = hit.transform;
                    holding = !holding;
                    hit.rigidbody.isKinematic = true;
                    
                    hit.rigidbody.freezeRotation = false;
                    hit.transform.position = this.transform.position;
                }
            }
            else
            {
                holdRb = currentHold.GetComponentInParent<Rigidbody>();
                holdRb.useGravity = true;
                currentHold.transform.parent = null;
                holdRb.freezeRotation = false;
                holding = !holding;
                holdRb.isKinematic = false;
            }
        }
        if(holding)
        {
            holdRb = currentHold.GetComponentInParent<Rigidbody>();
            holdRb.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
