using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class Enemy : MonoBehaviour
{
    //What is their health?
    public float health = 100f;
    //Reference to the game controller.
    public GameObject gameControl;
    public GameController control;
    //Reference to the nav mesh on the char.
    public NavMeshAgent navMeshAgent;
    //Who will he chase?
    public Transform player;
    //How much damage?
    public int damage = 1;
    private void Start()
    {
        //Automatically grab the components in case i forget to set it.
        navMeshAgent = GetComponent<NavMeshAgent>();
        control = gameControl.GetComponent<GameController>();
        
    }
    private void Update()
    {
        //If you're in the pause menu or if the player is dead or if they're in some UI or if level complete, don't do any of the code below.
        if (PauseMenu.GameIsPaused || control.levelComplete || control.isDead || EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        //Refresh the location of the player in case he moves.
        navMeshAgent.SetDestination(player.position);
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        //if their health goes to 0 or below, kill them and add a +1 to the score.
        if(health <= 0f)
        {
            Die();
            gameControl.GetComponent<GameController>().AddScore(1);
        }
    }
    void Die()
    {
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
