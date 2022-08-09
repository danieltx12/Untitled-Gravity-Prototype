using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    Health hp;
    [SerializeField] float dpsTime;
    public bool inField = false;

    private void OnTriggerEnter(Collider other)
    {
        hp = other.gameObject.GetComponent<Health>();
        inField = !inField;
        StartCoroutine(dot());
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            hp = other.gameObject.GetComponent<Health>();
            inField = !inField;
            StopCoroutine(dot());
        }
        
    }


    private IEnumerator dot()
    {
        while (inField)
        {
            hp.damage();
            Debug.Log(hp.health);
            yield return new WaitForSeconds(dpsTime);
            
        }
    }
}
