using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject inventoryItemPrefab; // Prefab for displaying inventory items
    public Transform inventoryGrid; // Parent transform for the grid layout
    public GameObject inventoryPanel; // Assign this in the Inspector
    public Text inventoryTitleText; // Text component for the inventory title

    void Start()
    {
        if (gameManager == null)
        {
            gameManager = FindObjectOfType<GameManager>();
        }

        if (gameManager != null)
        {
            if (gameManager.playerInventory != null)
            {
                gameManager.playerInventory.onInventoryChanged += UpdateInventoryUI;
            }
            else
            {
                Debug.LogError("PlayerInventory not found in the GameManager.");
            }
        }
        else
        {
            Debug.LogError("GameManager not found in the scene.");
        }

        // Ensure the inventory panel is initially hidden
        if (inventoryPanel != null)
        {
            inventoryPanel.SetActive(false);
        }

        // Ensure the inventory title text is initially hidden
        if (inventoryTitleText != null)
        {
            inventoryTitleText.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
            if (inventoryPanel.activeSelf)
            {
                UpdateInventoryUI();
                if (inventoryTitleText != null)
                {
                    inventoryTitleText.gameObject.SetActive(true);
                }
            }
            else
            {
                if (inventoryTitleText != null)
                {
                    inventoryTitleText.gameObject.SetActive(false);
                }
            }
        }
    }

    // Update the inventory UI
    void UpdateInventoryUI()
    {
        if (inventoryPanel.activeSelf && inventoryGrid != null)
        {
            DisplayInventory();
        }
    }

    // Display the inventory on the UI
    void DisplayInventory()
    {
        // Clear existing items
        foreach (Transform child in inventoryGrid)
        {
            Destroy(child.gameObject);
        }

        // Add new items
        foreach (var item in gameManager.playerInventory.items)
        {
            GameObject newItem = Instantiate(inventoryItemPrefab, inventoryGrid);
            Text itemText = newItem.GetComponentInChildren<Text>();
            if (itemText != null)
            {
                itemText.text = $"{item.Name}: {item.Quantity}";
            }
        }
    }
}
