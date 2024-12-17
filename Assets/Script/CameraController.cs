using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 cameraOffSet;
    public int sensitivity;
    public float mouseX;
    public float mouseY;
    public Transform playerPosition;

    public float maxYAngle = 80f;
    private float rotationX = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * sensitivity;
        mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -maxYAngle, maxYAngle);

        transform.rotation = Quaternion.Euler(rotationX, playerPosition.rotation.eulerAngles.y, 0f);
        transform.parent.Rotate(Vector3.up * mouseX);
    }
}


