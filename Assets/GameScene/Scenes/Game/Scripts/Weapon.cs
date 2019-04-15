using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : PickUp
{
    public int damage;
    public float attackSpeed;

    protected override Item CreateItem(){
        return new WeaponItem(objectName, weight, itemImage, damage, attackSpeed);
    }
}