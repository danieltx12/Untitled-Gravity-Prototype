using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravFlip : MonoBehaviour
{
    PlayerMovement playerMovement;
    GameObject player;
    CharacterController characterController;
    public bool isFlipped = false;
    private void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        characterController = FindObjectOfType<CharacterController>();
        player = GameObject.FindGameObjectWithTag("Player");
    }


    private void Update()
    {
        if(Input.GetButtonDown("Fire2"))
        {
            Debug.Log("FIRE2");
            PlayerFlip();
            PhysicsFlip();
            
        }
    }

    private void PlayerFlip()
    {
        characterController.enabled = !characterController.enabled;
        playerMovement.gravity *= -1;
        playerMovement.velocity.y = 0;
        if (!isFlipped)
        {
            player.transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        else
        {
            player.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        isFlipped = !isFlipped;
        characterController.enabled = !characterController.enabled;
    }

    private void PhysicsFlip()
    {
        Physics.gravity = Physics.gravity * -1;
    }
}
