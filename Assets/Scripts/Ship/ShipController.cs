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
        Vector3 movement = new Vector3(moveInput.x, 0f, moveInput.y);
        movement.Normalize();

        rb.MovePosition(transform.position + movement * moveSpeed * Time.fixedDeltaTime);

        if (movement != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            float rotationStep = rotationSpeed * Time.fixedDeltaTime;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationStep);
        }
    }



}
