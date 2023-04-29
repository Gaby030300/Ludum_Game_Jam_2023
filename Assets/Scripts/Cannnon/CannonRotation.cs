
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CannonRotation : MonoBehaviour
{
    private Vector2 movementInput;

    public void OnMove(InputValue value)
    {
        movementInput= value.Get<Vector2>();
        
    }

    private void FixedUpdate()
    {
        float xRot = transform.localRotation.eulerAngles.x;
        float yRot = transform.localRotation.eulerAngles.y;
        float zRot = transform.localRotation.eulerAngles.z;

        Vector3 finalRotation = new Vector3(xRot - movementInput.y, yRot + movementInput.x, zRot);

        transform.localRotation = Quaternion.Euler(finalRotation);
        LimitRotation();
        
    }

    void LimitRotation()
    {
        Vector3 playerEulerAngles = transform.localRotation.eulerAngles;

        playerEulerAngles.y = (playerEulerAngles.y > 180) ? playerEulerAngles.y - 360 : playerEulerAngles.y;
        playerEulerAngles.y = Mathf.Clamp(playerEulerAngles.y, -10, 10);

        playerEulerAngles.x = (playerEulerAngles.x > 180) ? playerEulerAngles.x - 360 : playerEulerAngles.x;
        playerEulerAngles.x = Mathf.Clamp(playerEulerAngles.x, -10, 30);

        transform.localRotation = Quaternion.Euler(playerEulerAngles);
    }
}
