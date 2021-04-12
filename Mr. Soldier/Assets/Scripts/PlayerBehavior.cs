using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayerBehavior : MonoBehaviour
{
    [Header("Components")]
    //Reference to character components
    public CharacterController controller;
    public GameController control;
    public HealthBar healthBar;
    public Joystick joystick;
    public LayerMask groundMask;
    public Transform groundCheck;
    public GameObject miniMap;
    public SceneDataSO sceneData;
    public Quest quest;

    [Header("Mobile Controls")]
    public float horizSen;
    public float vertSen;

    [Header("Stats")]
    public float speed = 12f;
    public float jumpHeight = 3f;
    //Health System
    public int maxHealth = 150;
    public int currentHealth;
    //Gravity variable
    public float gravity = -9.81f;
    //Store our velocity from the up/down axis
    Vector3 velocity;

    [Header("Ground")]
    //Check if we're on the floor
    public float groundDistance = 0.4f;
    private bool isGrounded;

    void Awake()
    {
        if(PlayerPrefs.GetInt("LoadingBool") == 0)
        {
            this.controller.enabled = false;
            this.transform.position = sceneData.playerPosition;
            this.transform.rotation = sceneData.playerRotation;
            this.controller.enabled = true;

            this.currentHealth = sceneData.playerHealth;
            this.healthBar.SetHealth(sceneData.playerHealth);
        }
    }
    void Start()
    {
        control = FindObjectOfType<GameController>();
        controller = GetComponent<CharacterController>();
        //Setting our health
        currentHealth = maxHealth;
        healthBar.currentHealth = currentHealth;
    }
    // Update is called once per frame
    void Update()
    {
        //Check if we're grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        Movement();

        //MiniMap (WebGL/Desktop)
        //if (Input.GetKeyDown(KeyCode.M))
        //{
        //    MiniMap();
        //}

    }
    public void Movement()
    {
        if (isGrounded && velocity.y < 0)
        {
            //Reset our weight once we land on the ground
            velocity.y = -2f;
        }

        //Jump code (WebGL/Desktop)
        //if (Input.GetButtonDown("Jump") && isGrounded)
        //{
        //    Jump();
        //}

        //Grab inputs (WebGL/Desktop)
        //float x = Input.GetAxis("Horizontal");
        //float z = Input.GetAxis("Vertical");

        //Mobile Controls
        float x = joystick.Horizontal;
        float z = joystick.Vertical;

        //Turn the inputs to a direction
        Vector3 move = transform.right * x + transform.forward * z;

        //Code to move
        controller.Move(move * speed * Time.deltaTime);

        //How to weigh us down
        velocity.y += gravity * Time.deltaTime;

        //Add the weight to our player
        controller.Move(velocity * Time.deltaTime);

        if (quest.isActive)
        {
            if(this.transform.position.x != -4.2f)
            {
                quest.goal.leftJoystickMoved = true;
                quest.goal.MovementDone();
            }
        }
    }
    public void TakeDamage(int damage)
    {
        //Whatever damage we take, subtract from our current health and set our health onto the health bar
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        //If you're dead, run this
        if(currentHealth <= 0)
        {
            control.EndGame();
        }
    }
    public void HealDamage(int heal)
    {
        //Heal whatever amount the first aid gives.
        currentHealth += heal;
        healthBar.SetHealth(currentHealth);
        if (quest.isActive)
        {
            quest.goal.HealingDone();
        }
    }
    void Jump()
    {
        if (isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            //Used for Quest
            if (quest.isActive)
            {
                quest.goal.jumpButtonPressed = true;
                quest.goal.JumpDone();
            }
        }
    }
    public void JumpButton()
    {
        Jump();
    }
    void MiniMap()
    {
        miniMap.SetActive(!miniMap.activeInHierarchy);
        if (quest.isActive)
        {
            quest.goal.miniMapButtonPressed = true;
            quest.goal.MiniMapDone();
        }
    }
    public void MiniMapButton()
    {
        MiniMap();
    }
}
