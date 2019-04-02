using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raft : MonoBehaviour, IInteractable
{
    public GameObject player;

    public void Action()
    {
        Debug.Log("hey");
        player.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 2, this.transform.position.z);
        this.transform.parent = player.transform;
    }
}
