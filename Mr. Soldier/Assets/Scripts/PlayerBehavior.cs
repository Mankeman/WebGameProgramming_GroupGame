using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    //Reference to the character controller, so that we can move.
    public CharacterController controller;

    //How fast are we going?
    public float speed = 12f;

    //Gravity variable
    public float gravity = -9.81f;

    //Check if we're on the floor.
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private bool isGrounded;

    //How to jump.
    public float jumpHeight = 3f;

    //Store our velocity from the up/down axis
    Vector3 velocity;

    // Update is called once per frame
    void Update()
    {
        //Check if we're grounded.
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(isGrounded && velocity.y < 0)
        {
            //Reset our weight once we land on the ground
            velocity.y = -2f;
        }
        //Grab inputs.
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //Turn the inputs to a direction
        Vector3 move = transform.right * x + transform.forward * z;

        //Code to move.
        controller.Move(move * speed * Time.deltaTime);

        //Jump code
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        //How to weigh us down.
        velocity.y += gravity * Time.deltaTime;

        //Add the weight to our player
        controller.Move(velocity * Time.deltaTime);


    }
}
