using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPPMovimentoRigidBody : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 2f;
    [SerializeField] private float gravityStrength = 9.81f; // Adjust gravity strength as needed

    private Rigidbody rb;
    private Transform playerCamera;
    private float pitch = 0.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerCamera = Camera.main.transform;

        // Lock the cursor for a smoother experience
        Cursor.lockState = CursorLockMode.Locked;

        // Set the Rigidbody's gravity
        rb.useGravity = false; // Disable the Rigidbody's built-in gravity
    }

    void Update()
    {
        // Player movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        // Rotate the player based on mouse input
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        transform.Rotate(Vector3.up * mouseX);

        // Rotate the camera (looking up and down) based on mouse input
        float mouseY = -Input.GetAxis("Mouse Y") * rotationSpeed;
        pitch += mouseY;
        pitch = Mathf.Clamp(pitch, -90.0f, 90.0f);
        playerCamera.localRotation = Quaternion.Euler(pitch, 0, 0);

        // Calculate gravity force
        Vector3 gravity = Vector3.down * gravityStrength;

        // Apply gravity using Rigidbody
        rb.AddForce(gravity, ForceMode.Acceleration);

        // Move the player using Rigidbody
        Vector3 move = transform.TransformDirection(direction);
        rb.velocity = move * moveSpeed;
    }
}