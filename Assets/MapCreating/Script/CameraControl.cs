using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class CameraControl : MonoBehaviour
{
    public Terrain CurTerrain;
    public GameObject selectionCube;
    public GameObject[] PlaceObjects;

    public GameObject AreaPrefab;

    private Camera _camera;
    private Material _selectMaterial;
    private Map _map;
    private GameObject _heldgameObject;

    public float Speed;
    public float ScrollSpeed;

    private bool isHorizontal;

    private Color32 SCGreen, SCRed;

    private readonly int _camHeight = 20;

    private bool _paused;

    //temp
    private Vector3 startPos;
    private bool selectionDown;

    private void Start()
    {
        int terrainDivider = 2;
        this.transform.position = new Vector3((CurTerrain.terrainData.size.x / terrainDivider), _camHeight, (CurTerrain.terrainData.size.z / terrainDivider));

        _map = new Map("MyPrison");
        _camera = this.GetComponent<Camera>();
        _selectMaterial = selectionCube.GetComponent<MeshRenderer>().material;
        _heldgameObject = PlaceObjects[0];

        isHorizontal = true;
        SCGreen = new Color32(46, 204, 113, 100);
        SCRed = new Color32(242, 38, 19, 150);
    }

    public void ChangeHeldObject(int index)
    {
        _heldgameObject = PlaceObjects[index];
        Object curObject = _heldgameObject.GetComponent<Object>();
        selectionCube.transform.localScale = new Vector3(curObject.xSize, 0.5f, curObject.zSize);
    }

    private void Update()
    {
        if (!_paused)
        {
            if (Input.GetMouseButton(0)) PlaceItem();
            if (Input.GetMouseButton(1)) RemoveItem();
            if (Input.GetMouseButtonDown(1) && Input.GetKey(KeyCode.LeftShift)) MakeSelection();
            if (Input.GetMouseButtonUp(1)) EndSelection();
            if (Input.GetKeyDown(KeyCode.R)) RotateItem(); 
            
            //Basic movement
            Move();
            Zoom();

            if (selectionDown)
                UpdateSelection();
            else
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
                _selectMaterial.color = SCGreen;
            else
                _selectMaterial.color = SCRed;
        }

        
        Object curObject = _heldgameObject.GetComponent<Object>();
        float xPos = isHorizontal ? ((curObject.xSize - 1) * 0.50f) : ((curObject.zSize - 1) * 0.50f);
        float zPos = isHorizontal ? ((curObject.zSize - 1) * 0.50f) : ((curObject.xSize - 1) * 0.50f);
        selectionCube.transform.position = new Vector3(Mathf.RoundToInt(mousePos.x) + xPos, 15, Mathf.RoundToInt(mousePos.z) + zPos);
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

    private void RotateItem()
    {
        selectionCube.transform.Rotate(new Vector3(0, 90, 0), Space.World);
        isHorizontal = !isHorizontal;
    }

    private void PlaceItem()
    {
        RaycastHit hit;
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.CompareTag("Terrain") && !EventSystem.current.IsPointerOverGameObject())
            {
                Object curObject = _heldgameObject.GetComponent<Object>();
                float xPos = isHorizontal ? ((curObject.xSize - 1) * 0.50f) : ((curObject.zSize - 1) * 0.50f);
                float zPos = isHorizontal ? ((curObject.zSize - 1) * 0.50f) : ((curObject.xSize - 1) * 0.50f);
                GameObject placedObj = Instantiate(_heldgameObject, new Vector3(Mathf.RoundToInt(hit.point.x) + xPos, 0, Mathf.RoundToInt(hit.point.z) + zPos), Quaternion.identity, hit.transform);
               
                placedObj.transform.Rotate(new Vector3(0, selectionCube.transform.eulerAngles.y, 0));
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
            if (hit.transform.gameObject.GetComponent<Object>() && !EventSystem.current.IsPointerOverGameObject())
            {
                _map.RemoveObject(hit.transform.gameObject);
                Destroy(hit.transform.gameObject);
            }
        }
    }

    private void MakeSelection()
    {
        RaycastHit hit;
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            startPos = new Vector3(Mathf.RoundToInt(hit.point.x), 15, Mathf.RoundToInt(hit.point.z));
            selectionCube.transform.position = startPos;
            selectionDown = true;
        }
    }

    private void UpdateSelection()
    {
        RaycastHit hit;
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 newPoint = new Vector3(Mathf.RoundToInt(hit.point.x) + 1, 14, Mathf.RoundToInt(hit.point.z) - 1);
            selectionCube.transform.localScale = startPos - newPoint;
            selectionCube.transform.position = startPos - new Vector3((selectionCube.transform.localScale.x / 2) + 0.5f, 0, (selectionCube.transform.localScale.z / 2) - 0.5f);
        }
    }

    private void EndSelection()
    {
        GameObject Area = Instantiate(AreaPrefab);
        Area.transform.position = selectionCube.transform.position;
        Area.transform.localScale = selectionCube.transform.localScale;

        selectionDown = false;
        Object curObject = _heldgameObject.GetComponent<Object>();
        selectionCube.transform.localScale = new Vector3(curObject.xSize, 0.5f, curObject.zSize);
    }

    public void SaveData()
    {
        string json = JsonUtility.ToJson(_map);
        Debug.Log(json);
    }
}
