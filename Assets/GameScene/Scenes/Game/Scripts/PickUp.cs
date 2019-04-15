using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickUp : MonoBehaviour, IInteractable
{
    public string objectName;
    public float weight;
    public Sprite itemImage;

    public void Action(){
        if(Inventory.instance.AddItem(CreateItem())){
            gameObject.SetActive(false);
        }
    }

    protected abstract Item CreateItem();
}
