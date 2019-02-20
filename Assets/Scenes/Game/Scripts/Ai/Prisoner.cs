using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Prisoner : Human
{
    private Prison curPrison;

    public Prisoner(string hName, uint weight, uint health, uint armor, int skinColor, int authority) : base(hName, weight, health, armor, skinColor, authority)
    {

    }

    public Prison GetPrison(){
        return curPrison;
    }

    public void SetPrison(Prison prison){
        this.curPrison = prison;
    }
}
