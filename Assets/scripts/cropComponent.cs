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

    // Detect mouse click on crop object
    private void OnMouseDown()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.HarvestCrop(crop);
    }

    // Detect 'F' key press when player is near the crop
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            GameManager gameManager = FindObjectOfType<GameManager>();
            gameManager.HarvestCrop(crop);
            Destroy(gameObject); // Destroy the crop GameObject
        }

        // Update crop growth
        crop.Grow(Time.deltaTime);
    }
}
