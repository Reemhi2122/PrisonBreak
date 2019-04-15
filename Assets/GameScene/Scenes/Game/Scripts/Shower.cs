using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Shower : Room
{
    public ShowerHead[] showerheads;
    private List<ShowerHead> unUsedShowers = new List<ShowerHead>();

    private void Start()
    {
        unUsedShowers = showerheads.ToList();
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    public ShowerHead GetShower()
    {
        ShowerHead curShower = unUsedShowers[Random.Range(0, (unUsedShowers.Count - 1))];
        unUsedShowers.Remove(curShower);
        return curShower;
    }
}
