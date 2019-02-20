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

    public Prison GetFreePrison(){
        for (int i = 0; i < Prisons.Count; i++)
        {
            if(Prisons[i].CheckIfOccupied() == false){
                return Prisons[i];
            }
        }
        return null;
    }
}
