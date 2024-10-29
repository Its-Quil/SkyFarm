using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CropComponent : MonoBehaviour
{
    private Crop crop;

    public void Initialize(Crop crop)
    {
        this.crop = crop;
        // Set visual representation based on crop properties
    }

    // Additional methods for harvesting, etc.
}
