
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CannonRotation : MonoBehaviour
{
    [Header("Horizontal Angles")]
    [SerializeField] float horizontalMinAngle = -10;
    [SerializeField] float horizontalMaxAngle = 10;
    [Header("Vertical Angles")]
    [SerializeField] float verticalMinAngle = -30;
    [SerializeField] float verticalMaxAngle = 10;


    [Header("Transform")]
    [SerializeField] Transform cannonTransform;

    private Vector2 movementInput;

    public void OnMove(InputValue value)
    {
        movementInput = value.Get<Vector2>();
        
    }

    private void FixedUpdate()
    {
        float xRot = cannonTransform.localRotation.eulerAngles.x;
        float yRot = cannonTransform.localRotation.eulerAngles.y;
        float zRot = cannonTransform.localRotation.eulerAngles.z;

        Vector3 finalRotation = new Vector3(xRot - movementInput.y, yRot + movementInput.x, zRot);

        cannonTransform.localRotation = Quaternion.Euler(finalRotation);
        LimitRotation();
        
    }

    void LimitRotation()
    {
        Vector3 playerEulerAngles = cannonTransform.localRotation.eulerAngles;

        playerEulerAngles.y = (playerEulerAngles.y > 180) ? playerEulerAngles.y - 360 : playerEulerAngles.y;
        playerEulerAngles.y = Mathf.Clamp(playerEulerAngles.y, horizontalMinAngle, horizontalMaxAngle);

        playerEulerAngles.x = (playerEulerAngles.x > 180) ? playerEulerAngles.x - 360 : playerEulerAngles.x;
        playerEulerAngles.x = Mathf.Clamp(playerEulerAngles.x, verticalMinAngle, verticalMaxAngle);

        cannonTransform.localRotation = Quaternion.Euler(playerEulerAngles);
    }
}
