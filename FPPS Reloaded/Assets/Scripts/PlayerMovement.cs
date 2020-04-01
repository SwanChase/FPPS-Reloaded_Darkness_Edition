﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 12f;
    public float dashDistance;
    public float gravity = -9.81f;
    public float jumpHeight;

    public Transform groundCheck, ceilingCheck;
    public float sphereRadius = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    bool isRoofed;

    


    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, sphereRadius, groundMask);
        isRoofed = Physics.CheckSphere(ceilingCheck.position, sphereRadius, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        if (isRoofed)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            controller.Move(move * dashDistance * Time.deltaTime);
        }
        else
        {
            controller.Move(move * speed * Time.deltaTime);
        }
        

        if (Input.GetButton("Jump") && isGrounded)
        {
            Debug.Log("YEEEEET");
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}