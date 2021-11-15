using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
    GameObject player;
    PlayerHealth playerHealth;
    PlayerMovement playerMovement;
    bool isInRange;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        playerMovement = player.GetComponent<PlayerMovement>();
        isInRange = false;
    }

    private void Update()
    {
        if (isInRange == true)
        {
            playerHealth.AddHealth(30);
            playerMovement.AddSpeed(3);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player && other.isTrigger == false && playerHealth.currentHealth < 100)
        {
            isInRange = true;
        }      
    }
}
