using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    private void Update(){
        transform.position = Vector3.Slerp(this.transform.position, new Vector3(player.position.x, 10f, player.position.z), 0.4f);
    }
}
