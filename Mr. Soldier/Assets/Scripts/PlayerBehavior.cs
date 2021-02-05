using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    //Reference to character components
    public CharacterController controller;
    private Animator anim;
    private bool isDead = false;

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

    void Start()
    {
        //Grabbing the animator component from the player.
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void FixedUpdate()
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

        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Fire 1 pressed");
        }
        //Our animator is gonna use these variables.
        anim.SetFloat("Speed", Mathf.Abs(x));
        anim.SetBool("isSprinting", Input.GetKeyDown(KeyCode.LeftShift));
        anim.SetBool("isCrouching", Input.GetKeyDown(KeyCode.LeftControl));
        anim.SetBool("throwingGrenade", Input.GetButtonDown("Fire1"));
        anim.SetBool("isDead", isDead);
    }
}
