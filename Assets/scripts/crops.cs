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

    // Simulate the growth of the crop
    public void Grow()
    {
        if (CurrentGrowthStage < GrowthTime)
        {
            CurrentGrowthStage++;
        }
    }

    // Plant the crop at the specified position
    public void PlantCrop(Crop crop, Vector3 position)
    {
        GameObject cropObject = GameObject.Instantiate(cropPrefab, position, Quaternion.identity);
        cropObject.GetComponent<CropComponent>().Initialize(crop);
    }

    // Harvest the crop if it is ready
    public void HarvestCrop(Crop crop)
    {
        if (crop.IsHarvestable)
        {
            GameObject.Destroy(crop.cropPrefab);
        }
    }
}
