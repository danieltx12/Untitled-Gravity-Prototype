using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    float walkSpeed = 12f;
    public float jumpHeight = 3f;
    bool isSprint = false;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float SprintMultiplier = 1.75f;
    GravFlip gravFlip;



    public Vector3 velocity;
    bool isGrounded;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        gravFlip = FindObjectOfType<GravFlip>();
    }

    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0 && !gravFlip.isFlipped)
        {
            velocity.y = -2f;
        }
        if (isGrounded && velocity.y > 0 && gravFlip.isFlipped)
        {
            velocity.y = 2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        if (z <= 0)
        {
            if (isSprint)
            {
                speed = walkSpeed;
                isSprint = !isSprint;
                Debug.Log("walking!");
            }
        }

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            if (!gravFlip.isFlipped)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
            else
            {
                Debug.Log("JUMP");
                velocity.y = (Mathf.Sqrt(jumpHeight * -2f * (gravity) * -1)) * -1;
            }
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetButtonDown("Fire1"))
        {
            if (isSprint)
            {
                speed = walkSpeed;
                isSprint = !isSprint;
                Debug.Log("walking!");
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (isSprint)
            {
                speed = walkSpeed;
                isSprint = !isSprint;
                Debug.Log("walking!");
            }
            else
            {
                isSprint = !isSprint;
                speed *= SprintMultiplier;
                Debug.Log("sprinting!");             
            }
        }

    }

    

}

