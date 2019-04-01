using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prison : Room
{
    private int cellId;
    public GameObject bed;
    public GameObject toilet;
    public Door door;
    private Prisoner prisoner = null;

    public bool ShouldClose = false;

    public void SetPrisonId(int prisonID)
    {
        cellId = prisonID;
    }

    public bool CheckIfOccupied()
    {
        if (prisoner == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void SetPrisoner(Prisoner prisoner)
    {
        this.prisoner = prisoner;
    }

    public void OpenDoor()
    {
        door.Open();
    }

    public void CloseDoor()
    {
        door.Close();
    }

    //This is only editor work
    public void SetAllProperties()
    {
        door = gameObject.GetComponentInChildren<Door>();
        bed = gameObject.transform.GetChild(1).gameObject;
        toilet = gameObject.transform.GetChild(2).gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PrisonerNPC>()) {
            if (other.gameObject.GetComponent<PrisonerNPC>().GetPrisonerClass() == prisoner)
            {
                if (ShouldClose) {
                    CloseDoor();
                }
            }
        }
    }
}
