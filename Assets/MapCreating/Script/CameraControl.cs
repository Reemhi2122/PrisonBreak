using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Terrain curTerrain;
    public GameObject tempObj;

    public float Speed;

    private readonly int _camHeight = 20;

    private bool _paused;

    public void Awake()
    {
        int terrainDivider = 2;
        this.transform.position = new Vector3((curTerrain.terrainData.size.x / terrainDivider), _camHeight, (curTerrain.terrainData.size.z / terrainDivider));
    }

    private void Update()
    {
        if (!_paused)
        {
            if (Input.GetMouseButtonDown(0)) PlaceItem();
            Move();
        }
    }

    private void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        this.transform.Translate(movement * Speed * Time.deltaTime);
    }

    private void PlaceItem()
    {
    }
}
