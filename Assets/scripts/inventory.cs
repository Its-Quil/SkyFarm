using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour
{
    public List<InventoryItem> items = new List<InventoryItem>();

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

    public void PrintInventory()
    {
        foreach (var item in items)
        {
            Debug.Log($"{item.Name}: {item.Quantity}");
        }
    }
}
