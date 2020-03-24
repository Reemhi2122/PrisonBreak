using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : PickUp
{
    public DoorSecurityType keyType;

    protected override Item CreateItem()
    {
        return new KeyItem(objectName, weight, itemImage, keyType);
    }
}
