using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public static RoomManager instance;
    public List<Shower> showers;
    public List<Canteen> canteens;
    public List<PrisonArchive> PrisonBlocks;

    private void Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    /// <summary>
    /// Gets closest shower
    /// </summary>
    /// <param name="curAI"></param>
    /// <returns>The closest shower</returns>
    public Shower GetClosestShower(GameObject curAI)
    {
        if (showers.Count == 1) return showers[0];
        float curDistance = 0;
        Shower returnShower = null;
        for (int i = 0; i < showers.Count; i++)
        {
            float latestDistance = Vector3.Distance(curAI.transform.position, showers[i].gameObject.transform.position);
            if (curDistance != 0)
            {
                if (latestDistance < curDistance)
                {
                    curDistance = latestDistance;
                    returnShower = showers[i];
                }
            } else
            {
                curDistance = latestDistance;
                returnShower = showers[i];
            }
        }
        return returnShower;
    }

    public Canteen GetClosestCanteen(GameObject curAI)
    {
        if (canteens.Count == 1) return canteens[0];
        float curDistance = 0;
        Canteen returnCanteens = null;
        for (int i = 0; i < canteens.Count; i++)
        {
            float latestDistance = Vector3.Distance(curAI.transform.position, canteens[i].gameObject.transform.position);
            if (curDistance != 0)
            {
                if (latestDistance < curDistance)
                {
                    curDistance = latestDistance;
                    returnCanteens = canteens[i];
                }
            }
            else
            {
                curDistance = latestDistance;
                returnCanteens = canteens[i];
            }
        }
        return returnCanteens;

    }
}
