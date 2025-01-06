using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForageableComponent : MonoBehaviour
{
    private Forageable item;

    // Public property to access the forageable item
    public Forageable Item { get; private set; }

    // Initialize the component with a Forageable item
    public void Initialize(Forageable item)
    {
        this.item = item;
        this.Item = item; // Ensure the public property is set
        // Set visual representation based on item properties if needed
    }

    // Detect 'E' key press when player is near the forageable item
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && item.IsAvailable)
        {
            GameManager gameManager = FindObjectOfType<GameManager>();
            gameManager.CollectForageable(item);
            Destroy(gameObject); // Destroy the forageable GameObject
        }
    }
}
