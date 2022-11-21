using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteLookCam : MonoBehaviour
{
    public CameraManager _camManager;
    void Start()
    {
        _camManager = FindObjectOfType<CameraManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(_camManager._mainCam.transform.position, Vector3.up);
    }
}
