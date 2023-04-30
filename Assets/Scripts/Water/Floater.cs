using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour
{
    [Header("Water Characteristics")]
    [SerializeField] private float deapthBeforeSumerged = 1f;
    [SerializeField] private float displacementAmount = 3f;
    [SerializeField] private int floaterCount = 1;
    [SerializeField] private float waterDrag = 0.99f;
    [SerializeField] private float waterAngularDrag = 0.5f;
    [SerializeField] private Rigidbody shipRigidbody;

    float displacementMultiplier;

    void Start()
    {
        shipRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        ShipMovement();
    }
    private void ShipMovement()
    {
        shipRigidbody.AddForceAtPosition(Physics.gravity / floaterCount, transform.position, ForceMode.Acceleration);
        float waveHeight = WaveManager.instance.GetWaveHeight(transform.position.x) + WaveManager.instance.transform.position.y;
        if (transform.position.y < waveHeight)
        {
            displacementMultiplier = Mathf.Clamp01((waveHeight - transform.position.y) / deapthBeforeSumerged) * displacementAmount;
            shipRigidbody.AddForceAtPosition(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacementAmount, 0f), transform.position, ForceMode.Acceleration);
            shipRigidbody.AddForce(displacementMultiplier * Time.fixedDeltaTime * waterDrag * -shipRigidbody.velocity, ForceMode.VelocityChange);
            shipRigidbody.AddTorque(displacementMultiplier * Time.fixedDeltaTime * waterAngularDrag * -shipRigidbody.angularVelocity, ForceMode.VelocityChange);

        }
    }
}
