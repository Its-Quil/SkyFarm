using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject cropPrefab;
    public GameObject forageablePrefab;
    public Inventory playerInventory;
    public GameOverUI gameOverUI; // Reference to the GameOverUI script

    private List<Crop> crops = new List<Crop>();
    private List<Forageable> forageables = new List<Forageable>();

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

    void Start()
    {
        // Example of planting a crop
        Crop newCrop = new Crop("Wheat", 5);
        crops.Add(newCrop);
        PlantCrop(newCrop, new Vector3(0, 2, 0)); // Position based on your scene

        // Example of spawning a forageable item
        SpawnForageableItem(new Vector3(3, 2, 0)); // Position based on your scene
    }

    void Update()
    {
        // Update the growth of crops
        foreach (var crop in crops)
        {
            crop.Grow();
            if (crop.IsHarvestable)
            {
                // Notify player that the crop is ready to harvest
            }
        }

        // Update the availability of forageable items
        foreach (var item in forageables)
        {
            if (item.IsAvailable)
            {
                // Notify player that items are available to collect
            }
        }

        // Plant a crop when 'R' is pressed
        if (Input.GetKeyDown(KeyCode.R))
        {
            PlantCrop(new Crop("Wheat", 5), new Vector3(0, 2, 0)); // Example position
        }
    }

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
        //PlayerManager.instance.player.GetComponent<PlayerMovement>().enabled = false;
    }
}
