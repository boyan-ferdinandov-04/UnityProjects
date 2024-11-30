using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SphereControl1 : MonoBehaviour
{
    public Rigidbody rb; 
    public Transform camera;
    public InputAction playerControls; 

    public float moveSpeed = 6f;
    public float jumpForce = 300f;
    private Vector3 moveDirection;

    private bool isGrounded;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    void Start()
    {
        rb.interpolation = RigidbodyInterpolation.Interpolate;

    }

    private void OnEnable()
    {
        playerControls.Enable(); 
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    void Update()
    {
        // Checking if player is grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        Debug.DrawLine(groundCheck.position, groundCheck.position + Vector3.down * groundDistance, Color.red);

        Vector2 inputMovement = playerControls.ReadValue<Vector2>();
        Vector3 forward = camera.forward;
        Vector3 right = camera.right;

        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        moveDirection = (forward * inputMovement.y + right * inputMovement.x).normalized;

        if (moveDirection.magnitude >= 0.1f)
        {
            rb.AddForce(moveDirection * moveSpeed, ForceMode.Force);
        }

        if (Keyboard.current.spaceKey.wasPressedThisFrame && isGrounded)
        {
            Jump();
        }
    }

    private void Jump()
    {

        SoundManagerScript.PlaySound("jump");
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    
}
