using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prisoner : Human
{

    private int cellNum;

    public Prisoner(uint weight, uint health, uint armor, int cellNum) : base(weight, health, armor)
    {
        this.cellNum = cellNum;
    }

    public int GetCellNum(){
        return cellNum;
    }

    public void SetCellNum(int cellNum){
        this.cellNum = cellNum;
    }
}
