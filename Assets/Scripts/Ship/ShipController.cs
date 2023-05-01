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

        if (localMovement != Vector3.zero)
        {
            float targetAngle = Mathf.Atan2(localMovement.x, localMovement.z) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0, targetAngle, 0);
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        transform.position += transform.forward * localMovement.magnitude * moveSpeed * Time.deltaTime;
    }



}
