using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crop
{
    public string Name { get; set; }
    public int GrowthTime { get; set; } // in days
    public int CurrentGrowthStage { get; set; } // 0 to GrowthTime
    public bool IsHarvestable => CurrentGrowthStage >= GrowthTime;

    public GameObject cropPrefab;

    public Crop(string name, int growthTime)
    {
        Name = name;
        GrowthTime = growthTime;
        CurrentGrowthStage = 0;
    }

<<<<<<< HEAD
    // Simulate the growth of the crop
    public void Grow(float deltaTime)
=======
    public void Grow()
>>>>>>> parent of e00ce79e (i added some scripts)
    {
        if (CurrentGrowthStage < GrowthTime)
        {
<<<<<<< HEAD
            CurrentGrowthTime += deltaTime;
=======
            CurrentGrowthStage++;
>>>>>>> parent of e00ce79e (i added some scripts)
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
        }
    }
}
