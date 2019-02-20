using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Room : MonoBehaviour
{
    private GameObject[] door;

    private void Awake()
    {
        Door[] sdoor;
        sdoor = this.gameObject.GetComponentsInChildren<Door>();
        door = new GameObject[sdoor.Length];
        for (int i = 0; i < sdoor.Length; i++)
        {
            door[i] = sdoor[i].gameObject;
        }
    }

    public GameObject GetDoor()
    {
        return door[Random.Range(0, (door.Length - 1))];
    }

    public GameObject GetDoorClosest(GameObject curObj)
    {
        float closestdistance = 0;
        GameObject closestDoor = null;
        for (int i = 0; i < door.Length; i++)
        {
            if (closestdistance != 0)
            {
                float distance = Vector3.Distance(door[i].transform.position, curObj.transform.position);
                if (distance < closestdistance)
                {
                    closestdistance = distance;
                    closestDoor = curObj;
                }
            }
            else
            {
                float distance = Vector3.Distance(door[i].transform.position, curObj.transform.position);
                closestdistance = distance;
                closestDoor = curObj;
            }
        }
        return closestDoor;
    }
}