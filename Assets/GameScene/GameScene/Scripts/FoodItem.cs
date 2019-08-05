using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodItem : Item
{
    public int healthGain;
    public int staminaGain;

    public FoodItem(string name, float weight, Sprite itemImage, int healthGain, int staminaGain) : base(name, weight, itemImage){
        this.healthGain = healthGain;
        this.staminaGain = staminaGain;
    }
}
