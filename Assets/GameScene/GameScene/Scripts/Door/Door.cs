using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{

    public DoorType type;
    public OpenType openType;
    public DoorSecurityType doorSecurityType;
    private int CellDoorId;
    private float health;
    public bool isOpen;
    private bool isAnimating;

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
        if (doorSecurityType == DoorSecurityType.NoSecurity || Inventory.instance.HasKey(doorSecurityType)) {
            if (!isOpen)
            {
                isAnimating = true;

                if (openType == OpenType.X)
                    _tween = LeanTween.moveLocalX(this.gameObject, (this.transform.transform.localPosition.x - 1.5f), 0.5f);
                else if (openType == OpenType.Z)
                    _tween = LeanTween.moveLocalZ(this.gameObject, (this.transform.transform.localPosition.z - 1.5f), 0.5f);

                _tween.setOnComplete(() =>
                {
                    isAnimating = false;
                });
                isOpen = true;
            }
        }
    }

    public void Close()
    {
        if (doorSecurityType == DoorSecurityType.NoSecurity || Inventory.instance.HasKey(doorSecurityType))
        {
            if (isOpen)
            {
                isAnimating = true;

                if (openType == OpenType.X)
                    _tween = LeanTween.moveLocalX(this.gameObject, (this.gameObject.transform.localPosition.x + 1.5f), 0.5f);
                else if (openType == OpenType.Z)
                    _tween = LeanTween.moveLocalZ(this.gameObject, (this.gameObject.transform.localPosition.z + 1.5f), 0.5f);

                _tween.setOnComplete(() =>
                {
                    isAnimating = false;
                });
                isOpen = false;
            }
        }
    }

    public void Action()
    {
        if (!isAnimating)
        {
            if (isOpen)
                Close();
            else
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

public enum OpenType
{
    X,
    Z
}

public enum DoorSecurityType
{
    NoSecurity,
    MediumSecurity,
    HeavySecurity
}
