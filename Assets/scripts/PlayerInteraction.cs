using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private CropComponent currentCrop;
    private Vector3 farmPlotPosition;
    private GameManager gameManager;
    private Item currentItem;
    private Item heldItem;
    public Transform holdPosition; // Position where the item will be held

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        if (gameManager == null)
        {
            Debug.LogError("GameManager not found in the scene.");
        }
    }

    // This method is called when the player enters a trigger collider
    private void OnTriggerEnter(Collider other)
    {
        if (gameManager == null) return;

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

        // Check if the player is close to a farm plot
        if (other.CompareTag("FarmPlot"))
        {
            farmPlotPosition = other.transform.position;
        }

        // Check if the player is close to an item
        if (other.CompareTag("Item"))
        {
            currentItem = other.GetComponent<Item>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Crop"))
        {
            currentCrop = null;
        }

        if (other.CompareTag("FarmPlot"))
        {
            farmPlotPosition = Vector3.zero;
        }

        if (other.CompareTag("Item"))
        {
            currentItem = null;
        }
    }

    private void Update()
    {
        if (gameManager == null) return;

        if (currentCrop != null && Input.GetKeyDown(KeyCode.F))
        {
            gameManager.HarvestCrop(currentCrop.Crop);
            Destroy(currentCrop.gameObject); // Destroy the crop GameObject
        }

        if (farmPlotPosition != Vector3.zero && Input.GetKeyDown(KeyCode.F))
        {
            gameManager.PlantSeed("SeedName", farmPlotPosition); // Replace "SeedName" with the actual seed name
        }

        if (currentItem != null && Input.GetKeyDown(KeyCode.E))
        {
            PickUpItem(currentItem);
        }

        if (heldItem != null && Input.GetKeyDown(KeyCode.Q))
        {
            PutDownItem();
        }

        if (heldItem != null)
        {
            heldItem.transform.position = holdPosition.position;
            heldItem.transform.rotation = holdPosition.rotation;
        }
    }

    public void PickUpItem(Item item)
    {
        if (heldItem == null)
        {
            heldItem = item;
            item.PickUp();
            item.transform.SetParent(holdPosition); // Parent the item to the hold position
            Debug.Log($"Picked up {item.itemName}");
        }
    }

    public void PutDownItem()
    {
        if (heldItem != null)
        {
            heldItem.PutDown();
            heldItem.transform.SetParent(null); // Unparent the item
            heldItem.transform.position = transform.position + transform.forward; // Place the item in front of the player
            Debug.Log($"Put down {heldItem.itemName}");
            heldItem = null;
        }
    }
}

