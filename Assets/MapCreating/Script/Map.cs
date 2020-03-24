using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Map
{
    private int _mapSize;
    private string _mapName;

    [HideInInspector]
    public int[] _map;

    public Map(string a_Name)
    {
        _mapName = a_Name;
        _mapSize = 200;
        _map = new int[_mapSize * _mapSize];
    }

    /// <summary>
    /// Get the name of the selected map.
    /// </summary>
    /// <returns>Map name</returns>
    public string GetMapName() { return _mapName; }

    // ----------- Logic ----------- \\

    public void AddObject(GameObject a_AddedItem)
    {
        Vector3 pos = a_AddedItem.transform.position;

        //Debug.Log((int)pos.x + (int)pos.z * 100);
        _map[(int)pos.x + (int)pos.z * 100] = a_AddedItem.GetComponent<Object>().objectID;
        //Debug.Log("Item: " + a_AddedItem + " has been added to the position: x " + pos.x + ", z " + pos.z + ". Map name: " + _mapName + ".");
    }

    public void RemoveObject(GameObject a_AddedItem)
    {
        Vector3 pos = a_AddedItem.transform.position;
        _map[(int)pos.x + (int)pos.z * 100] = 0;
        Debug.Log("Item: " + a_AddedItem + " has been removed to the position: x " + pos.x + ", z " + pos.z + ". Map name: " + _mapName + ".");
    }
}
