using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ShipIconRotation : MonoBehaviour
{    void LateUpdate()
    {
        transform.rotation = Quaternion.Euler(90f, 0f, 180f);
    }
}
