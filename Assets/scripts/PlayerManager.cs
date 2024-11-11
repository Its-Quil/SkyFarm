using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    public GameObject player;
    public Transform respawnPoint; // Add a respawn point

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RespawnPlayer()
    {
        // Respawn the player at the respawn point
        player.transform.position = respawnPoint.position;
        player.GetComponent<Health>().ResetHealth();
    }
}
