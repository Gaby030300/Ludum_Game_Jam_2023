using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChanger : MonoBehaviour
{
    public Camera firstPersonCamera;
    public Camera[] thirdPersonCameras;
    public KeyCode switchCameraKey = KeyCode.E;

    private int currentCameraIndex = 0;

    public bool isThirdPerson = true;
    void Start()
    {
        firstPersonCamera.enabled = true;
        firstPersonCamera.depth = 1;
        foreach (Camera cam in thirdPersonCameras)
        {
            cam.enabled = false;
        }
        isThirdPerson = true;
    }


    void Update()
    {
        if (Input.GetKeyDown(switchCameraKey))
        {
            currentCameraIndex = (currentCameraIndex + 1) % (thirdPersonCameras.Length + 1);
            if (currentCameraIndex == 0)
            {
                firstPersonCamera.enabled = true;
                isThirdPerson = true;                
                foreach (Camera cam in thirdPersonCameras)
                {
                    cam.enabled = false;                    
                }
            }
            else
            {
                firstPersonCamera.enabled = false;
                isThirdPerson = false;                               
                for (int i = 0; i < thirdPersonCameras.Length; i++)
                {                    
                    if (i == currentCameraIndex - 1)
                    {
                        thirdPersonCameras[i].enabled = true;
                    }
                    else
                    {
                        thirdPersonCameras[i].enabled = false;
                    }
                }
            }
        }
    }
}
