using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item
{
    public string name {get; private set;}
    public float weight {get; private set;}
    public Sprite itemImage;

    public Item(string name, float weight, Sprite itemImage){
        this.name = name;
        this.weight = weight;
        this.itemImage = itemImage;
    }
}
