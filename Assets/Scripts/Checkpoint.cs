using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    public Transform checkpointMem;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        checkpointMem.transform.position = this.gameObject.transform.position;
    }
}
