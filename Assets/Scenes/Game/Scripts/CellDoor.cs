using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellDoor : MonoBehaviour, IInteractable
{
    public int CellDoorId;
    private bool isOpen;

    LTDescr _tween;

    public void Open(){
        if(Inventory.instance.HasKey(CellDoorId)){
            _tween = LeanTween.moveZ(this.gameObject, (this.transform.transform.position.z - 1.5f), 0.5f);
        }
    }

    public void Action(){
        Open();
    }
}
