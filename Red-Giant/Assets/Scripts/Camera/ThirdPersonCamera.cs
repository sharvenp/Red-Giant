using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ThirdPersonCamera : MonoBehaviour
{
    public float cameraMoveSpeed = 120f;
    public GameObject cameraFollowObj;
    Vector3 followPos;
    public float clampAngle = 80f;
    public float inputSensitivity = 150f;

    private float rotY = 0f;
    private float rotX = 0f;

    private void Start()
    {
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;

        LockMouse();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            LockMouse();
        }

        float mouseX = Input.GetAxisRaw("Mouse X");
        float mouseY = -Input.GetAxisRaw("Mouse Y");

        rotY += mouseX * inputSensitivity;
        rotX += mouseY * inputSensitivity;

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = localRotation;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnlockMouse();
        }
    }

    private void FixedUpdate()
    {
        CameraUpdater();
    }

    private void LockMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void UnlockMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void CameraUpdater()
    {
        Transform target = cameraFollowObj.transform;

        float step = cameraMoveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }
}
