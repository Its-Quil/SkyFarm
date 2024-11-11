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
        // Set visual representation based on item properties if needed
    }

    // Detect mouse click on forageable item to collect it
    private void OnMouseDown()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (item.IsAvailable)
        {
            gameManager.CollectForageable(item);
        }
    }
}
