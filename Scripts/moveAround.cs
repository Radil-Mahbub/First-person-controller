using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveAround : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 10f;
    public float gravity = -9.8f;
    public float jumpHeight = 3f;

    Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //takes in data for X and Y axis movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //move the player in relation to where its looking
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        //gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }
}
