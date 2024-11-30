using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class SphereControl : MonoBehaviour
{
    public float jumpForce = 2.0f;
    public float moveSpeed = 4.0f;
    private bool isGrounded;

    public InputAction movementAction;
    public InputAction jumpAction;
    // Reference to the camera
    public Transform cameraTransform; 

    private Rigidbody rb;
    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    void OnCollisionExit()
    {
        isGrounded = false;
    }

    private void OnEnable()
    {
        movementAction.Enable();
        jumpAction.Enable();

        // Subscribe to jump action
        jumpAction.performed += OnJump;
    }

    private void OnDisable()
    {
        movementAction.Disable();
        jumpAction.Disable();

        // Unsubscribe from jump action
        jumpAction.performed -= OnJump;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputDirection = movementAction.ReadValue<Vector2>();

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        moveDirection = (forward * inputDirection.y + right * inputDirection.x).normalized;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.deltaTime);
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        if (isGrounded)
        {
            // Applying jump force
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
}
