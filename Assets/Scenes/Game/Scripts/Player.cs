using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera PlayerCamera;
    private float speed = 5;

    void Update()
    {
        Move();
        Rotate();

        if (Input.GetMouseButtonDown(0)){
            SendRay();
        }
    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        this.transform.position += new Vector3(horizontal, 0, vertical) * speed * Time.deltaTime;
    }

    private void Rotate()
    {
        Ray ray = PlayerCamera.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, Vector3.zero);
        float distance;
        if (plane.Raycast(ray, out distance))
        {
            Vector3 target = ray.GetPoint(distance);
            Vector3 direction = target - transform.position;
            float rotation = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, rotation, 0);
        }
    }

    private void SendRay()
    {
        Ray ray = PlayerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.CompareTag("Interactable"))
            {
                if (Vector3.Distance(this.transform.position, hit.transform.position) < 4)
                {
                    hit.transform.gameObject.GetComponent<IInteractable>().Action();
                }
            }
        }
    }
}