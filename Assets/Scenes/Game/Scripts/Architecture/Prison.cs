using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prison : Room
{
    private int cellId;
    private GameObject bed;
    private GameObject toilet;
    private Prisoner prisoner = null;

    public Prison(){
        
    }

    public void SetPrisonId(int prisonID){
        cellId = prisonID;
    }

    public bool CheckIfOccupied(){
        if(prisoner == null){
            return false;
        } else {
            return true;
        }
    }

    public void SetPrisoner(Prisoner prisoner){
        this.prisoner = prisoner;
    }
}
