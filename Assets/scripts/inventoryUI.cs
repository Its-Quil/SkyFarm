using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameManager gameManager;
    public Text inventoryText; // Assign this in the Inspector
    public GameObject inventoryPanel; // Assign this in the Inspector

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
        }

        if (inventoryPanel.activeSelf)
        {
            DisplayInventory();
        }
    }

    // Display the inventory on the UI
    void DisplayInventory()
    {
        inventoryText.text = "";
        foreach (var item in gameManager.playerInventory.items)
        {
            inventoryText.text += $"{item.Name}: {item.Quantity}\n";
        }
    }
}
