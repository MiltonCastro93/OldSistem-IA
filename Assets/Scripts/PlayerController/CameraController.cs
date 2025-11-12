using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float sensivity = 1.0f;
    [SerializeField] private float angleMax = 45f;
    Transform cam;
    private float pitch = 0f; // Rotación vertical acumulada

    void Start() {
        cam = Camera.main.transform;
        Cursor.lockState = CursorLockMode.Locked; // Bloquea el cursor
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update() {
        ControllerCam();
    }

    private void ControllerCam() {
        float mouseX = Input.GetAxis("Mouse X") * sensivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensivity;

        // Rotación horizontal (Yaw)
        transform.Rotate(Vector3.up * mouseX);

        // Rotación vertical (Pitch)
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, -angleMax, angleMax);
        cam.localRotation = Quaternion.Euler(pitch, 0f, 0f);


    }


}
