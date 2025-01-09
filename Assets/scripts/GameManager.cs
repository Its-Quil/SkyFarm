using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    public GameObject cropPrefab;
    public GameObject forageablePrefab;
    private List<Crop> crops = new List<Crop>();
    private List<ForageableItem> forageableItems = new List<ForageableItem>();

    void Start()
    {
        // Example of planting a crop
        Crop newCrop = new Crop("Wheat", 180); // 3 minutes growth time
        crops.Add(newCrop);
        PlantCrop(newCrop, new Vector3(0, 0, 0)); // Position based on your scene

        // Example of spawning a forageable item
        SpawnForageableItem(new Vector3(1, 0, 0)); // Position based on your scene
    }

    public void PlantCrop(Crop crop, Vector3 position)
    {
        GameObject cropObject = Instantiate(cropPrefab, position, Quaternion.identity);
        cropObject.GetComponent<CropComponent>().Initialize(crop); // You'll need to create CropComponent
    }

    public void SpawnForageableItem(Vector3 position)
    {
        GameObject forageableObject = Instantiate(forageablePrefab, position, Quaternion.identity);
        forageableObject.GetComponent<ForageableComponent>().Initialize(new ForageableItem("Berry")); // You'll need to create ForageableComponent
    }

    void Update()
    {
        foreach (var crop in crops)
        {
            crop.Grow(Time.deltaTime);
            if (crop.IsHarvestable)
            {
                // Notify player that the crop is ready to harvest
            }
        }

        foreach (var item in forageableItems)
        {
            if (item.IsAvailable)
            {
                // Notify player that items are available to collect
            }
        }
    }
<<<<<<< Updated upstream
=======

    // Plant a crop at the specified position
    public void PlantCrop(Crop crop, Vector3 position)
    {
        GameObject cropObject = Instantiate(cropPrefab, position, Quaternion.identity);
        CropComponent cropComponent = cropObject.GetComponent<CropComponent>();
        if (cropComponent != null)
        {
            cropComponent.Initialize(crop);
        }
    }

    // Spawn a forageable item at the specified position
    public void SpawnForageableItem(Vector3 position)
    {
        GameObject forageableObject = Instantiate(forageablePrefab, position, Quaternion.identity);
        Forageable newForageable = new Forageable("Berry", forageableObject);
        forageableObject.GetComponent<ForageableComponent>().Initialize(newForageable);
        forageables.Add(newForageable);
    }

    // Harvest a crop if it is ready
    public void HarvestCrop(Crop crop)
    {
        if (crop.IsHarvestable)
        {
            playerInventory.AddItem(crop.Name);
            Destroy(crop.cropPrefab);
        }
    }

    // Collect a forageable item if it is available
    public void CollectForageable(Forageable item)
    {
        if (item.IsAvailable)
        {
            playerInventory.AddItem(item.Name);
            item.IsAvailable = false;
            Destroy(item.GameObject);
        }
    }

    // Handle player death
    public void GameOver()
    {
        // Display game over UI
        Debug.Log("Game Over!");
        if (gameOverUI != null)
        {
            Debug.Log("Calling ShowGameOverUI");
            gameOverUI.ShowGameOverUI();
        }
        else
        {
            Debug.LogError("GameOverUI is not assigned in the GameManager.");
        }

        // Optionally, disable player controls
        // PlayerManager.instance.player.GetComponent<PlayerController>().enabled = false;
    }

    // Create a farm plot at the specified position
    public void CreateFarmPlot(Vector3 position)
    {
        // Implement logic to create a farm plot (e.g., change terrain texture, instantiate a farm plot object, etc.)
    }

    // Plant a seed if the player has it in their inventory
    public void PlantSeed(string seedName, Vector3 position)
    {
        if (playerInventory.items.Exists(item => item.Name == seedName && item.Quantity > 0))
        {
            Crop newCrop = new Crop(seedName, 180); // 3 minutes growth time
            crops.Add(newCrop);
            PlantCrop(newCrop, position);
            playerInventory.RemoveItem(seedName);
        }
    }
>>>>>>> Stashed changes
}
