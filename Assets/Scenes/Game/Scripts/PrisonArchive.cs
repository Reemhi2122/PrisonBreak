using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrisonArchive : MonoBehaviour
{

    public static PrisonArchive instance = null;

    public List<Prison> Prisons = new List<Prison>();

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        for (int i = 0; i < Prisons.Count; i++)
        {
            Prisons[i].SetPrisonId(i + 1);
        }
    }

    private void OnEnable()
    {
        EventManager.OnPrisonStateChanged += OnEvent;
    }

    private void OnDisable()
    {
        EventManager.OnPrisonStateChanged -= OnEvent;
    }

    private void OnEvent(PrisonState type)
    {
        switch (type) {
            case PrisonState.Eating:
                OpenAllDoors();
                break;
            case PrisonState.FreeTime:
                OpenAllDoors();
                break;
            case PrisonState.LockUp:
                SetAllDoorsToClose();
                break;
            case PrisonState.Shower:
                OpenAllDoors();
                break;
            case PrisonState.Sleep:
                SetAllDoorsToClose();
                break;
            case PrisonState.Work:
                OpenAllDoors();
                break;
        }
    }

    public Prison GetFreePrison()
    {
        for (int i = 0; i < Prisons.Count; i++)
        {
            if (Prisons[i].CheckIfOccupied() == false)
            {
                return Prisons[i];
            }
        }
        return null;
    }

    public void SetAllDoorsToClose()
    {
        for (int i = 0; i < Prisons.Count; i++)
        {
            Prisons[i].ShouldClose = true;
        }
    }

    public void CloseAllDoors()
    {
        for (int i = 0; i < Prisons.Count; i++)
        {
            Prisons[i].CloseDoor();
        }
    }

    public void OpenAllDoors()
    {
        for (int i = 0; i < Prisons.Count; i++)
        {
            Prisons[i].OpenDoor();
            Prisons[i].ShouldClose = false;
        }
    }

    public void AddAllPrisonProperties(){
        for (int i = 0; i < Prisons.Count; i++)
        {
            Prisons[i].SetAllProperties();
        }
    }
}
