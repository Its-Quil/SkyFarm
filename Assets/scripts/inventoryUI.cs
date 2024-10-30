using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameManager gameManager;
    public Text inventoryText; // Assign this in the Inspector

    void Update()
    {
        DisplayInventory();
    }

    void DisplayInventory()
    {
        inventoryText.text = "";
        foreach (var item in gameManager.playerInventory.items)
        {
            inventoryText.text += $"{item.Name}: {item.Quantity}\n";
        }
    }
}
