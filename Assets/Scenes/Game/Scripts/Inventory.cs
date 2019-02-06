using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    private List<Item> items;
    public Image[] invSpaces = new Image[3];
    public float MaximumWeight = 10.0f;
    public float TotalWeight;

    void Awake(){
        if(instance == null){
            instance = this;
        } else {
            Destroy(this);
        }

        items = new List<Item>();
    }

    public bool AddItem(Item item){
        if(TotalWeight + item.weight > MaximumWeight){
            //TODO: Add feedback
            return false;
        }

        items.Add(item);
        TotalWeight += item.weight;
        DisplayItem(item);      
        return true;
    }

    public void RemoveItem(Item item){
        items.Remove(item);
        TotalWeight -= item.weight;
    }

    public void DisplayItem(Item item){
        for (int i = 0; i < invSpaces.Length; i++)
        {
            if(invSpaces[i].sprite == null){
                invSpaces[i].sprite = item.itemImage;
                invSpaces[i].enabled = true;
                break;
            }
        }
    }

    ///<summary>
    ///This function checks if you have the right key in the inventory
    ///</summary>
    public bool HasKey(int CDid){
        for (int i = 0; i < items.Count; i++)
        {
            if(items[0].name.Equals(CDid)){
                // TODO: make more complicated items and make this return true if the item is a key
                // and has the right id.
            }
        }

        return false;
    }

}
