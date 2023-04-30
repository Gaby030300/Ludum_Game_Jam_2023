using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipController : MonoBehaviour
{
    private Rigidbody rb;
    private Vector2 moveInput;
    public float rotationSpeed = 5f;
    public float moveSpeed = 5f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        MoveShip();
    }

    private void MoveShip()
    {
        Vector3 localMovement = transform.TransformDirection(moveInput.x, 0f, moveInput.y);
        localMovement.Normalize();

        rb.MovePosition(transform.position + localMovement * moveSpeed * Time.fixedDeltaTime);

        if (localMovement != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(localMovement);
            float rotationStep = rotationSpeed * Time.fixedDeltaTime;
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, targetRotation, rotationStep);
        }
    }



}
