using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public CharacterController characterController;
    public float speed = 10f;
    public float sprintMultiplier = 2f; // Multiplicador de velocidad al correr
    public float gravity = -9.81f;

    Vector3 velocity;

    public Transform groundCheck;
    public float sphereRadius = 0.3f;
    public LayerMask groundMask;

    bool isGrounded;

    public float jumpHeight = 5f;

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, sphereRadius, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        // Aplicar multiplicador de velocidad al correr (si se presiona Shift)
        float currentSpeed = speed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = sprintMultiplier * speed;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight -2f * gravity);
        }

        characterController.Move(move * currentSpeed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }
}