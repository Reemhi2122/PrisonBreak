using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Prisoner : Human
{
    protected Prison curPrison;

    //proper
    private string description;
    private float hunger;
    private float hygiene;
    private float joy;



    public Prisoner(string hName, uint weight, uint health, uint armor, float skinColor, int authority) : base(hName, weight, health, armor, skinColor, authority)
    {
        SetPrison(PrisonArchive.instance.GetFreePrison());
        GetPrison().SetPrisoner(this);
    }

    /// <summary>
    /// Get the prison of the prisoner
    /// </summary>
    /// <returns>The prison of the prisoner</returns>
    public Prison GetPrison(){
        return curPrison;
    }

    /// <summary>
    /// Set the prison of the prisoner
    /// </summary>
    /// <param name="prison"></param>
    public void SetPrison(Prison prison){
        this.curPrison = prison;
    }

    /// <summary>
    /// Returns description
    /// </summary>
    /// <returns>Description</returns>
    public string GetDescription()
    {
        return description;
    }

    /// <summary>
    /// Sets description
    /// </summary>
    /// <param name="a_Description"></param>
    public void SetDescription(string a_Description)
    {
        this.description = a_Description;
    }

    /// <summary>
    /// Returns hunger
    /// </summary>
    /// <returns>Hunger</returns>
    public float GetHunger()
    {
        return hunger;
    }

    /// <summary>
    /// Sets hunger
    /// </summary>
    /// <param name="a_Hunger"></param>
    public void SetHunger(float a_Hunger)
    {
        this.hunger = a_Hunger;
    }

    /// <summary>
    /// Returns hygiene
    /// </summary>
    /// <returns>Hygiene</returns>
    public float GetHygiene()
    {
        return hygiene;
    }

    /// <summary>
    /// Set hygiene
    /// </summary>
    /// <param name="a_Hygiene"></param>
    public void SetHygiene(float a_Hygiene)
    {
        this.hygiene = a_Hygiene;
    }

    /// <summary>
    /// Returns joy
    /// </summary>
    /// <returns>Joy</returns>
    public float GetJoy()
    {
        return this.joy;
    }


    /// <summary>
    /// Sets joy
    /// </summary>
    /// <param name="a_Joy"></param>
    public void setJoy(float a_Joy)
    {
        this.joy = a_Joy;
    }
}
