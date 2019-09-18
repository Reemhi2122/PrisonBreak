using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class WorldCreation : MonoBehaviour
{
    private string worldName;

    Map nMap;
    
    public void SetWorldName(string a_WorldName)
    {
        this.worldName = a_WorldName;
        Debug.Log(this.worldName);
    }

    public void CreateWorld()
    {
        nMap = new Map(this.worldName);

        this.gameObject.SetActive(false);
    }

    public void MenuScreen()
    {
        SceneManager.LoadScene(0);
    }
}
