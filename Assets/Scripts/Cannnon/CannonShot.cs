using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CannonShot : MonoBehaviour
{
    [SerializeField] float initialVelocity = 30;

    [SerializeField] GameObject pirate;
    [SerializeField] Transform shootposition;

    LoadCharacterCannon loadCharacterCannon;

    public void OnFire()
    {        
        ShipBoardList shipBoardList = FindObjectOfType<ShipBoardList>();
        if (shipBoardList.boardedCount > 0)
        {
            GameObject projectile = shipBoardList.GetLastCharacter().GO;
            projectile.transform.position = shootposition.position;
           // GameObject projectile = Instantiate(pirate,shootposition.position,Quaternion.identity);
            Rigidbody rb = projectile.GetComponent<CheckDetection>().rbProbe;
            rb.AddForce(shootposition.forward * initialVelocity, ForceMode.Impulse);

            projectile.transform.rotation = Quaternion.FromToRotation(Vector3.up,transform.forward);

            foreach (Rigidbody item in projectile.GetComponentsInChildren<Rigidbody>())
            {
                item.AddForce(shootposition.forward * initialVelocity, ForceMode.Impulse);
            }
        }
    }
}
