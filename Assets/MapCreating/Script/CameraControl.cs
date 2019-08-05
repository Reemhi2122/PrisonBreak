using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Terrain CurTerrain;
    public GameObject selectionCube;
    public GameObject[] PlaceObjects;

    private Camera _camera;
    private Material _selectMaterial;
    private Map _map;
    private GameObject _heldgameObject;

    public float Speed;
    public float ScrollSpeed;

    private readonly int _camHeight = 20;

    private bool _paused;

    private void Awake()
    {
        int terrainDivider = 2;
        this.transform.position = new Vector3((CurTerrain.terrainData.size.x / terrainDivider), _camHeight, (CurTerrain.terrainData.size.z / terrainDivider));
    }

    private void Start()
    {
        _map = new Map(200, "MyPrison");
        _camera = this.GetComponent<Camera>();
        _selectMaterial = selectionCube.GetComponent<MeshRenderer>().material;
        _heldgameObject = PlaceObjects[0];
    }

    public void ChangeHeldObject(int index)
    {
        _heldgameObject = PlaceObjects[index];
        Vector3 scale = _heldgameObject.transform.localScale;
        selectionCube.transform.localScale = new Vector3(scale.x, 0.5f, scale.z);
    }

    private void Update()
    {
        if (!_paused)
        {
            if (Input.GetMouseButton(0)) PlaceItem();
            if (Input.GetMouseButton(1)) RemoveItem();
            Move();
            Zoom();
            Selection();
        }
    }

    private void Selection()
    {
        Vector3 mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);

        RaycastHit hit;
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.CompareTag("Terrain"))
                _selectMaterial.color = new Color32(46, 204, 113, 100);
            else 
                _selectMaterial.color = new Color32(242, 38, 19, 150);
        }

        selectionCube.transform.position = new Vector3(Mathf.RoundToInt(mousePos.x), 15, Mathf.RoundToInt(mousePos.z));
    }

    private void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        this.transform.Translate(movement * Speed * Time.deltaTime);
    }

    private void Zoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        _camera.orthographicSize = Mathf.Clamp(_camera.orthographicSize + -scroll * ScrollSpeed * Time.deltaTime, 3 , 100);
    }

    private void PlaceItem()
    {
        RaycastHit hit;
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.CompareTag("Terrain") && !EventSystem.current.IsPointerOverGameObject())
            {
                GameObject placedObj = Instantiate(_heldgameObject, new Vector3(Mathf.RoundToInt(hit.point.x), (_heldgameObject.transform.localScale.y / 2), Mathf.RoundToInt(hit.point.z)), Quaternion.identity, hit.transform);
                _map.AddObject(placedObj);
            }
        }
    }

    private void RemoveItem()
    {
        RaycastHit hit;
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.CompareTag("Object") && !EventSystem.current.IsPointerOverGameObject())
            {
                _map.RemoveObject(hit.transform.gameObject);
                Destroy(hit.transform.gameObject);
            }
        }
    }
}
