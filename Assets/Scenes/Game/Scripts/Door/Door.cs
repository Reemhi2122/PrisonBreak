using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{

    public DoorType type;
    int CellDoorId;
    float health;
    bool isOpen;

    LTDescr _tween;

    void Awake()
    {
        switch (type)
        {
            case DoorType.NORMAL:
                health = 100;
                break;
            case DoorType.STAFF:
                health = 200;
                break;
            case DoorType.MANAGERDOOR:
                health = 200;
                break;
            case DoorType.CELLDOOR:
                health = 500;
                break;
            case DoorType.ISOLATEDOOR:
                health = 1000;
                break;
        }
    }

    public void Open()
    {
        _tween = LeanTween.moveX(this.gameObject, (this.transform.transform.position.x - 1.5f), 0.5f);
        isOpen = true;
    }

    public void Close()
    {
        _tween = LeanTween.moveX(this.gameObject, (this.gameObject.transform.position.x + 1.5f), 0.5f);
        isOpen = false;
    }

    public void Action()
    {
        if (isOpen) {
            Close();
        } else {
            Open();
        }
    }
}

public enum DoorType
{
    NORMAL,
    STAFF,
    MANAGERDOOR,
    CELLDOOR,
    ISOLATEDOOR
}
