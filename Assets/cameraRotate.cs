using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraRotate : MonoBehaviour
{
    public float speed = 3;

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {

        float mouseposY = Input.GetAxisRaw("Mouse Y");
        float mouseposX = Input.GetAxisRaw("Mouse X");
        transform.Rotate(-mouseposY, mouseposX, 0);
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 0);

        if (Input.GetKey(KeyCode.W))
            transform.position += transform.forward * speed;

        if (Input.GetKey(KeyCode.S))
            transform.position += -transform.forward * speed;

        if (Input.GetKey(KeyCode.D))
            transform.position += transform.right * speed;

        if (Input.GetKey(KeyCode.A))
            transform.position += -transform.right * speed;
    }
}
