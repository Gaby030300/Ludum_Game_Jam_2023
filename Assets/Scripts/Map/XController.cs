using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XController : MonoBehaviour
{
    [SerializeField] List<GameObject> exesList;
    Dictionary<string, GameObject> xDict = new Dictionary<string, GameObject>();

    [SerializeField] GameObject island1;
    [SerializeField] GameObject island2;
    [SerializeField] GameObject island3;
    [SerializeField] GameObject island4;

    private void Start()
    {
        exesList.Add(island1);
        exesList.Add(island2);
        exesList.Add(island3);
        exesList.Add(island4);
        xDict.Add("coconut",island1);
        xDict.Add("hack",island2);
        xDict.Add("treasure",island3);
        xDict.Add("shipwreck",island4);
    }
    
    public void ActivateCurrent(Character lastCharacter)
    {
        DisableIslands();
        switch (lastCharacter.destination)  
        {
            case Character.destinations.coconut:
                island1.SetActive(true);
                break;
            case Character.destinations.hacker:
                island2.SetActive(true);
                break;
            case Character.destinations.treasure:
                island3.SetActive(true);
                break;
            case Character.destinations.shipwreck:
                island4.SetActive(true);
                break;
            default:
                island1.SetActive(true);
                break;
        }
    }

    private void DisableIslands()
    {
        foreach (GameObject item in exesList)
        {
            item.SetActive(false);
        }
    }

}
