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
        Crop newCrop = new Crop("Wheat", 5);
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
            crop.Grow();
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
}
