using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map
{
    private int _mapSize;
    private string _mapName;
    private GameObject[,] _map;

    public Map(string a_Name)
    {
        _mapName = a_Name;
        _mapSize = 200;
        _map = new GameObject[_mapSize, _mapSize];
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

        _map[(int)pos.x, (int)pos.z] = a_AddedItem;
        //Debug.Log("Item: " + a_AddedItem + " has been added to the position: x " + pos.x + ", z " + pos.z + ". Map name: " + _mapName + ".");
    }

    public void RemoveObject(GameObject a_AddedItem)
    {
        Vector3 pos = a_AddedItem.transform.position;
        _map[(int)pos.x, (int)pos.z] = null;
        //Debug.Log("Item: " + a_AddedItem + " has been removed to the position: x " + pos.x + ", z " + pos.z + ". Map name: " + _mapName + ".");
    }
}
