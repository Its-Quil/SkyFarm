using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crop
{
    public string Name { get; set; }
    public float GrowthTime { get; set; } // in seconds
    public float CurrentGrowthTime { get; set; } // 0 to GrowthTime
    public bool IsHarvestable => CurrentGrowthTime >= GrowthTime;

    public GameObject cropPrefab;

    public Crop(string name, float growthTime)
    {
        Name = name;
        GrowthTime = growthTime;
        CurrentGrowthTime = 0;
    }

<<<<<<< Updated upstream
    public void Grow()
=======
    // Simulate the growth of the crop
    public void Grow(float deltaTime)
>>>>>>> Stashed changes
    {
        if (CurrentGrowthTime < GrowthTime)
        {
<<<<<<< Updated upstream
            CurrentGrowthStage++;
        }
    }

    public void PlantCrop(Crop crop, Vector3 position)
    {
        // Instantiate the crop at the specified position
        // You can create a Crop GameObject prefab
        GameObject cropObject = GameObject.Instantiate(cropPrefab, position, Quaternion.identity);
        cropObject.GetComponent<CropComponent>().Initialize(crop);
    }

    public void HarvestCrop(Crop crop)
    {
        if (crop.IsHarvestable)
        {
            // Give player item, destroy crop object
            GameObject.Destroy(crop.cropPrefab);
=======
            CurrentGrowthTime += deltaTime;
>>>>>>> Stashed changes
        }
    }
}
