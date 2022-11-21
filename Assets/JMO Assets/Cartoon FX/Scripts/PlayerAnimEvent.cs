using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimEvent : MonoBehaviour
{

    [SerializeField] Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    public void PlantStop()
    {
        print("Stop");
        PlayerBehaviour.instance._isPlanting = false;
        _animator.SetBool("Plant", false);
    }
}
