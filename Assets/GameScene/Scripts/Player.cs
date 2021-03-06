﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera PlayerCamera;

    private float normalSpeed;
    private float speed;
    private float FastForwardSpeedMultiplier;
    private float SprintMuliplier;

    private bool gamePaused;
    private bool FastForwardEnabled;

    private float maxVelocityChange = 10.0f;

    private Prison pPrison;

    private Rigidbody rb;

    private void Start()
    {
        normalSpeed = 10;
        speed = normalSpeed;
        FastForwardSpeedMultiplier = 2;
        SprintMuliplier = 1.5f;
        rb = GetComponent<Rigidbody>();
        pPrison = PrisonArchive.instance.GetFreePrison();
        this.transform.position = pPrison.transform.position;
    }
    private void OnEnable()
    {
        GameManager.OnGameStateChanged += GameStateChanged;
        Clock.OnFastForward += SetFastForward;
    }

    private void OnDisable()
    {
        GameManager.OnGameStateChanged -= GameStateChanged;
        Clock.OnFastForward -= SetFastForward;
    }

    private void Update()
    {
        if (!gamePaused) {
            //Rotate();
            //Move();
        }

        if (Input.GetMouseButtonDown(0)) SendRay();
        if (Input.GetKeyDown(KeyCode.LeftShift)) speed *= SprintMuliplier;
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            if (FastForwardEnabled) speed = normalSpeed * FastForwardSpeedMultiplier;
            else speed = normalSpeed;
        }
    }

    private void FixedUpdate()
    {
        if (!gamePaused)
        {
            Move();
        }
    }

    private void SetFastForward(bool enabled)
    {
        if (enabled) speed *= 2;
        else speed = normalSpeed;

        FastForwardEnabled = enabled;
    }

    private void GameStateChanged(GameState state)
    {
        switch (state)
        {
            case GameState.Init:
                break;
            case GameState.Pause:
                gamePaused = true;
                break;
            case GameState.Play:
                gamePaused = false;
                break;

        }
    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 pos = this.transform.position;
        Vector3 newPos = pos + (new Vector3(horizontal, 0, vertical) * speed * Time.deltaTime);

        rb.MovePosition(newPos);
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
            if (hit.collider.transform.CompareTag("Interactable") || hit.collider.transform.CompareTag("ShowerHead"))
            {
                if (Vector3.Distance(this.transform.position, hit.collider.transform.position) < 3)
                {
                    hit.collider.transform.gameObject.GetComponent<IInteractable>().Action();
                }
            }
            if (hit.collider.transform.CompareTag("Prisoner"))
            {
                Debug.Log("prisoner selected");
            }
        }
    }
}