using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatBouncing : MonoBehaviour
{
    public float bounceAmplitude = 0.1f;
    private void Update()
    {
        float newY = transform.position.y + Mathf.Sin(Time.time) * bounceAmplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
