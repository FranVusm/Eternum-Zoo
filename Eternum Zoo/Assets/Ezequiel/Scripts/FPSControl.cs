using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSControl : MonoBehaviour
{
    public float mouseSensitivite = 200f;
    public Transform playerBody;

    float XRotation = 0;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X")*mouseSensitivite*Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivite * Time.deltaTime;
        XRotation += mouseY;
        XRotation = Mathf.Clamp(XRotation,-90f, 90f);   
        transform.localRotation = Quaternion.Euler(XRotation, 0, 0);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
