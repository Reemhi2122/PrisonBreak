using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditModeScript : MonoBehaviour
{

    private int speed;
    private GameObject prefabObj;
    public Camera EditorCam;

    private void Start()
    {
        speed = 5;
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        this.transform.position += new Vector3(horizontal, 0, vertical) * speed * Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
            SendRay();
    }

    private void SendRay()
    {
        Ray ray = EditorCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            
        }
    }

    public void SwitchItem(GameObject a_Prefab)
    {
        prefabObj = a_Prefab;
    }

}
