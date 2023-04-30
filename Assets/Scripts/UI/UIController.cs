using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [Header("Map")]
    [SerializeField] GameObject map;

    void Update()
    {
        OpenMap();
    }
    public void OpenMap()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            map.SetActive(!map.gameObject.activeSelf);
            if (map.gameObject.activeSelf == true)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }

        }
    }
}
