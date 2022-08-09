using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{

    public GameObject player;
    CharacterController controller;
    void Start()
    {
        controller = player.GetComponent<CharacterController>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            controller.enabled = !controller.enabled;
            player.transform.position = this.transform.position;
            controller.enabled = !controller.enabled;

        }
    }
}
