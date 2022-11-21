using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{

    [SerializeField] Camera _cam;
    [SerializeField] Transform _origin;

    Vector3 _previousPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (_cam.transform.eulerAngles.x > 90)
        //{
        //    _cam.transform.eulerAngles = new Vector3(90, _cam.transform.eulerAngles.y, _cam.transform.eulerAngles.z);
        //}

        //if (_cam.transform.eulerAngles.x < 0)
        //{
        //    _cam.transform.eulerAngles = new Vector3(0, _cam.transform.eulerAngles.y, _cam.transform.eulerAngles.z);
        //}
        
        

        if (Input.GetMouseButtonDown(0))
        {
            _previousPos = _cam.ScreenToViewportPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 _dir = _previousPos - _cam.ScreenToViewportPoint(Input.mousePosition);

            _cam.transform.position = _origin.position;

            _cam.transform.Rotate(new Vector3(0.5f, 0, 0), _dir.y * 180);
            _cam.transform.Rotate(new Vector3(0, 1, 0), _dir.x * -180, Space.World);
            _cam.transform.Translate(new Vector3(0, 0, -41));

            _previousPos = _cam.ScreenToViewportPoint(Input.mousePosition);


        }

    }
}
