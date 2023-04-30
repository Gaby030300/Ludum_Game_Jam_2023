using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOverNormals : MonoBehaviour
{
    private void OnEnable()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position,-transform.up, out hit);

        Quaternion grndTilt = Quaternion.FromToRotation(Vector3.up, hit.normal);
        transform.rotation = grndTilt * transform.rotation;
        transform.position = hit.point;
    }
}
