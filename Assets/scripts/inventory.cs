using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour
{
    public List<InventoryItem> items = new List<InventoryItem>();

    // Add an item to the inventory
    public void AddItem(string itemName)
    {
        InventoryItem item = items.Find(i => i.Name == itemName);

        if (item != null)
        {
            item.Quantity++;
        }
        else
        {
            items.Add(new InventoryItem(itemName, 1));
        }
    }

    // Remove an item from the inventory
    public void RemoveItem(string itemName)
    {
        InventoryItem item = items.Find(i => i.Name == itemName);
        if (item != null)
        {
            item.Quantity--;
            if (item.Quantity <= 0)
            {
                items.Remove(item);
            }
        }
    }

    // Print the inventory to the console
    public void PrintInventory()
    {
        foreach (var item in items)
        {
            Debug.Log($"{item.Name}: {item.Quantity}");
        }
    }
}
