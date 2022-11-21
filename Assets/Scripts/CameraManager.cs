using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera _mainCam;

    public Camera[] _camList;
    void Start()
    {
        CamsOff(_camList[0]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CamsOff(Camera camON)
    {
        foreach (Camera cam in _camList)
        {
            cam.gameObject.SetActive(false);
        }

        camON.gameObject.SetActive(true);
        _mainCam = camON;
    }
}
