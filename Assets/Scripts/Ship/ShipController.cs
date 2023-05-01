using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipController : MonoBehaviour
{
    private Rigidbody rb;
    private Vector2 moveInput;

    [Header("Movement")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float maxSpeed = 10f;
    [SerializeField] private float acceleration = 2f;
    private float currentSpeed;

    [Header("Rotation")]
    [SerializeField] private float rotationSpeed = 5f;

    private bool isMoving = false;

    CameraChanger cameraChanger;

    private void Awake()
    {
        cameraChanger = FindObjectOfType<CameraChanger>();
        rb = GetComponent<Rigidbody>();
        currentSpeed = moveSpeed;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        if (moveInput != Vector2.zero && cameraChanger.isThirdPerson)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
    }

    private void Update()
    {
        MoveShip();
    }

    private void MoveShip()
    {
        if(isMoving)
        {
            Vector3 localMovement = transform.TransformDirection(moveInput.x, 0f, moveInput.y);
            localMovement.Normalize();
            transform.position += localMovement * currentSpeed * Time.fixedDeltaTime;            
            currentSpeed = Mathf.Clamp(currentSpeed + acceleration * Time.fixedDeltaTime, moveSpeed, maxSpeed);
            
            if (localMovement != Vector3.zero)
            {
                float targetAngle = Mathf.Atan2(localMovement.x, localMovement.z) * Mathf.Rad2Deg;
                Quaternion targetRotation = Quaternion.Euler(0, targetAngle, 0);
                transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }        
        else
        {
            currentSpeed = Mathf.Clamp(currentSpeed - acceleration * Time.fixedDeltaTime, moveSpeed, maxSpeed);
        }
    }

}
