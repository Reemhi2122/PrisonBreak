using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canteen : Room
{
    public List<CanteenChair> canteenChairs;
    public List<CanteenChair> unusedChairs;

    private void Start()
    {
        unusedChairs = canteenChairs;
    }

    public CanteenChair GetChair()
    {
        CanteenChair returnchair = unusedChairs[Random.Range(0, unusedChairs.Count - 1)];
        unusedChairs.Remove(returnchair);
        return returnchair;
    }
}
