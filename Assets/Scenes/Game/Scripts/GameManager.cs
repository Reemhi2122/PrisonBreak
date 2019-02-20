using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private void Awake(){
        Ini();
    }

    private void Ini(){
        for (int i = 0; i < 100; i++)
        {
            GameObject jordi = new GameObject();
            jordi.AddComponent<PrisonerNPC>();
        }
    }
}
