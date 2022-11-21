using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    public Transform _top;
    [SerializeField] MeshRenderer _mesh;
   
    void Start()
    {
        _mesh = GetComponent<MeshRenderer>();
        _mesh.enabled = false;
    }

    
}
