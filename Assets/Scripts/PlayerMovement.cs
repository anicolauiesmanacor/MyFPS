using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Transform cam;
    float hMouse, yMouse;
    float yReal = 0.0f;

    public float horSpeed;
    public float verSpeed;

    //movement
    public CharacterController controller;
    public float speed = 12f;
    float x, z = 0;
    Vector3 move;

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update() {
        LookMouse();
        Movement();
    }

    void LookMouse() { 
        hMouse = Input.GetAxis("Mouse X") * horSpeed * Time.deltaTime;
        yMouse = Input.GetAxis("Mouse Y") * verSpeed * Time.deltaTime;

        yReal -= yMouse;
        yReal = Mathf.Clamp(yReal, -90f, 90f);
        transform.Rotate(0f, hMouse, 0f);
        cam.localRotation = Quaternion.Euler(yReal, 0f, 0f);
    }

    void Movement() {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
    }
}
