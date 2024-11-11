using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forageable
{
    public string Name { get; set; }
    public bool IsAvailable { get; set; }
    public GameObject GameObject { get; set; }

    public Forageable(string name, GameObject gameObject)
    {
        Name = name;
        IsAvailable = true;
        GameObject = gameObject;
    }
}
