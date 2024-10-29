using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ForageableComponent : MonoBehaviour
{
    private ForageableItem item;

    public void Initialize(ForageableItem item)
    {
        this.item = item;
        // Set visual representation based on item properties
    }

    // Additional methods for collecting, etc.
}
