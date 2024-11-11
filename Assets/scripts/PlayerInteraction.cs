using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
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
            CropComponent cropComponent = other.GetComponent<CropComponent>();
            if (cropComponent != null && cropComponent.Crop != null)
            {
                gameManager.HarvestCrop(cropComponent.Crop);
                Destroy(other.gameObject); // Optionally destroy the GameObject after harvesting
            }
            else
            {
                Debug.LogError("CropComponent or Crop is null.");
            }
        }
    }
}

