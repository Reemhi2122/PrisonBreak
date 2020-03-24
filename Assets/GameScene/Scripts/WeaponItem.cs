using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItem : Item
{

    public int damage;
    public float attackSpeed;

    public WeaponItem(string name, float weight, Sprite itemImage, int damage, float attackSpeed) : base(name, weight, itemImage){
        this.damage = damage;
        this.attackSpeed = attackSpeed;
    }
}
