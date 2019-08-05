using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    private List<Item> items;
    public Image[] invSpaces = new Image[3];
    public float MaximumWeight = 10.0f;
    public float TotalWeight;

    public int equipedItem = 0;
    public Image equipindc;

    public TMP_Text InvText;

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
        InvText.text = equipedItem <= (items.Count - 1) ? items[equipedItem].name : "Fist";
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

    public bool HasKey(DoorSecurityType SDT){
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i] is KeyItem)
            {
                KeyItem ci = (KeyItem)items[i];
                if (ci.keyType == SDT)
                {
                    return true;
                }
            }
        }

        return false;
    }

    public void ChangeSelected(int selected)
    {
        equipedItem = selected;
        equipindc.transform.position = invSpaces[selected].transform.position;
        InvText.text = equipedItem <= (items.Count - 1) ? items[equipedItem].name : "Fist";
    }

}
