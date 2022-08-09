using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public Transform checkpoint;
    public int health = 10;
    CharacterController controller;
    Transform player;
    int count;
    // Start is called before the first frame update


    private void Start()
    {
        player = this.gameObject.transform;
        controller = GetComponent<CharacterController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 3)
        {
            health -= 1;
        }
    }

    private void Update()
    {
        if(health <= 0)
        {
            DamageZone[] damageZones = FindObjectsOfType<DamageZone>();
            controller.enabled = !controller.enabled;
            player.transform.position = checkpoint.transform.position;
            controller.enabled = !controller.enabled;
            foreach (DamageZone zone in damageZones)
            {
                zone.inField = !zone.inField;
            }
            health = 10;
        }
    }

    public void damage()
    {
        health -= 1;
    }
}
