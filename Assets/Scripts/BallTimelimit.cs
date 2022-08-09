using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTimelimit : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine("Kill");
    }
    IEnumerator Kill()
    {
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }
}
