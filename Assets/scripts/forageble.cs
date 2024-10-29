using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForageableItem
{
    public string Name { get; set; }
    public bool IsAvailable { get; set; }

    public ForageableItem(string name)
    {
        Name = name;
        IsAvailable = true;
    }
}
