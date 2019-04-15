using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : Item
{
    public DoorSecurityType keyType;

    public KeyItem(string name, float weight, Sprite itemImage, DoorSecurityType keyType) : base(name, weight, itemImage)
    {
        this.keyType = keyType;
    }
}
