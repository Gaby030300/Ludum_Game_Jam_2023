using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour
{
    [SerializeField] Transform compassNeedle;
    [SerializeField] Transform shipTransform;

    Vector3 rotationVector;
    

    void FixedUpdate()
    {
        rotationVector.y = shipTransform.eulerAngles.y;
        compassNeedle.localEulerAngles = rotationVector;
    }
}
