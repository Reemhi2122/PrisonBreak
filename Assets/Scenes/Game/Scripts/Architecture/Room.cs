using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Room : MonoBehaviour
{
    private GameObject[] doors;

    private void Awake()
    {
        Door[] sdoor;
        sdoor = this.gameObject.GetComponentsInChildren<Door>();
        doors = new GameObject[sdoor.Length];
        for (int i = 0; i < sdoor.Length; i++)
        {
            doors[i] = sdoor[i].gameObject;
        }
    }

    public GameObject GetDoor()
    {
        return doors[Random.Range(0, (doors.Length - 1))];
    }

    public GameObject GetDoorClosest(GameObject curObj)
    {
        float closestdistance = 0;
        GameObject closestDoor = null;
        for (int i = 0; i < doors.Length; i++)
        {
            if (closestdistance != 0)
            {
                float distance = Vector3.Distance(doors[i].transform.position, curObj.transform.position);
                if (distance < closestdistance)
                {
                    closestdistance = distance;
                    closestDoor = curObj;
                }
            }
            else
            {
                float distance = Vector3.Distance(doors[i].transform.position, curObj.transform.position);
                closestdistance = distance;
                closestDoor = curObj;
            }
        }
        return closestDoor;
    }
}