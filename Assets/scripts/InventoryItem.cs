using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class InventoryItem
    {
        public string Name;
        public int Quantity;

        public InventoryItem(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }
    }

