using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public GameObject footstep;
    [Header("Movement")]

    public float groundDrag;

    public float airMultiplier;
    public Transform camPos;

    public float walkSpeed;
    public float crouchSpeed;
    private float moveSpeed;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    private bool isCrouching = false;
    private float originalCamHeight;
    private float crouchCamHeight;
    public float crouchLerpSpeed = 10f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        moveSpeed = walkSpeed;

        // Initialize camera heights
        originalCamHeight = camPos.localPosition.y;
        crouchCamHeight = originalCamHeight - 0.6f;
    }

    private void Update()
    {
        // Footstep sound activation
        if (Mathf.Abs(rb.velocity.x) > 1 || Mathf.Abs(rb.velocity.z) > 1)
        {
            footstep.SetActive(true);
        }
        else
        {
            footstep.SetActive(false);
        }

        // Ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsGround);

        MyInput();
        SpeedControl();
        HandleDrag();

        // Crouch handling
        HandleCrouch();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        // Calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // On ground
        if (grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        // In air
        else
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // Limit velocity if needed
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void HandleDrag()
    {
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }

    private void HandleCrouch()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isCrouching = true;
            moveSpeed = crouchSpeed;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isCrouching = false;
            moveSpeed = walkSpeed;
        }

        float targetHeight = isCrouching ? crouchCamHeight : originalCamHeight;
        Vector3 targetPosition = new Vector3(camPos.localPosition.x, targetHeight, camPos.localPosition.z);
        camPos.localPosition = Vector3.Lerp(camPos.localPosition, targetPosition, Time.deltaTime * crouchLerpSpeed);
    }
}
