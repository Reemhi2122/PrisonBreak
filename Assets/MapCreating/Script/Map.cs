using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map
{
    private int _mapSize;
    private string _mapName;
    private GameObject[,] _map;

    public Map(int a_Size, string a_Name)
    {
        _mapSize = a_Size;
        _mapName = a_Name;
        InitMap();
    }

    private void InitMap()
    {
        _map = new GameObject[_mapSize, _mapSize];
        //Debug.Log("Map " + _mapName + " has been created!");
    }

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
