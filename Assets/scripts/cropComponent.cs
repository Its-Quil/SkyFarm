using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CropComponent : MonoBehaviour
{
    private Crop crop;

    // Public property to access the crop
    public Crop Crop { get; private set; }

    // Initialize the component with a Crop
    public void Initialize(Crop crop)
    {
        this.crop = crop;
        this.Crop = crop; // Ensure the public property is set
        // Set visual representation based on crop properties
    }

    // Detect 'E' key press when player is near the crop
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && crop.IsHarvestable)
        {
            GameManager gameManager = FindObjectOfType<GameManager>();
            gameManager.HarvestCrop(crop);
            Destroy(gameObject); // Destroy the crop GameObject
        }
    }
}

