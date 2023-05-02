using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;
/// <summary>
/// Si... tengo problemas al nombrar esta clase de esta forma pero algún día voy a arreglar alguna de estas cosas
/// </summary>
public class CheckDetection : MonoBehaviour
{
    [SerializeField] public Rigidbody rbProbe;
    bool isInPosition;    

    private void Start()
    {
    }

    private void Update()
    {
        if (rbProbe?.velocity.magnitude <= 0.1f && isInPosition)
        {
            ScorePoints();
        }
    }

    private void ScorePoints()
    {
        Debug.Log("SCORE!");
        //TODO: Change for poolsystem
        DestroyMe();
    }
    private void GetStrike()
    {
        DestroyMe();
    }

    private void DestroyMe()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("X"))
        {
            isInPosition = true;
            ScoreManager.Score++;

        }
        if (other.CompareTag("Water"))
        {
            ScoreManager.Strike++;
            GetStrike();
        }
        ///If Sea: GetStrick or something
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("X"))
        {
            isInPosition = false;  
        }        
    }
}
