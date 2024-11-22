using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private CropComponent currentCrop;

    // This method is called when the player enters a trigger collider
    private void OnTriggerEnter(Collider other)
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager == null)
        {
            Debug.LogError("GameManager not found in the scene.");
            return;
        }

        // Check if the player is close to a forageable item
        if (other.CompareTag("Forageable"))
        {
            ForageableComponent forageableComponent = other.GetComponent<ForageableComponent>();
            if (forageableComponent != null)
            {
                gameManager.CollectForageable(forageableComponent.Item);
                Destroy(other.gameObject); // Optionally destroy the GameObject after collection
            }
        }

        // Check if the player is close to a crop
        if (other.CompareTag("Crop"))
        {
            currentCrop = other.GetComponent<CropComponent>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Crop"))
        {
            currentCrop = null;
        }
    }

    private void Update()
    {
        if (currentCrop != null && Input.GetKeyDown(KeyCode.F))
        {
            GameManager gameManager = FindObjectOfType<GameManager>();
            gameManager.HarvestCrop(currentCrop.Crop);
            Destroy(currentCrop.gameObject); // Destroy the crop GameObject
        }
    }
}

