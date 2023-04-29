using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CannonShot : MonoBehaviour
{
    public float initialVelocity;

    public GameObject pirate;
    public Transform shootposition;
    public void OnFire()
    {
        GameObject projectile = Instantiate(pirate,shootposition.position,Quaternion.identity);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();

        projectile.transform.rotation = Quaternion.FromToRotation(Vector3.up,transform.forward);

        foreach (Rigidbody item in projectile.GetComponentsInChildren<Rigidbody>())
        {
            item.AddForce(shootposition.forward* initialVelocity,ForceMode.Impulse);
        }
    }
}
