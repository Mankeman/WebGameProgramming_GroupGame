using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class Enemy : MonoBehaviour
{
    [Header("Stats")]
    //What is their health?
    public int health = 100;

    //How much damage?
    public int damage = 1;

    [Header("Components")]
    public HealthBar healthBar;

    //Reference to the game controller.
    public GameController control;

    //Reference to the nav mesh on the char.
    public NavMeshAgent navMeshAgent;

    //Who will he chase?
    public Transform player;

    private void Start()
    {
        //Automatically grab the components in case i forget to set it.
        navMeshAgent = GetComponent<NavMeshAgent>();
        control = FindObjectOfType<GameController>();
        player = GameObject.Find("Soldier").transform;
        healthBar.SetHealth(health);
    }
    private void Update()
    {
        //Refresh the location of the player in case he moves.
        navMeshAgent.SetDestination(player.position);
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.SetHealth(health);
        if (health < 0)
        {
            control.AddScore(1);
            Die();
        }
    }
    public void Die()
    {
        //destroy the game object when they die
        Destroy(gameObject);
    }
    private void OnTriggerStay(Collider other)
    {
        //If you're touching the player (On Trigger Stay), make him take damage.
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerBehavior>().TakeDamage(damage);
        }
    }
}
