using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Feu : MonoBehaviour
{
    //public UnityEvent _onActivate;
    public Animator _animator;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Activate()
    {
        //_onActivate?.Invoke();
        _animator.SetBool("activate", true);
        print("activate");
    }

    public void DestroySelf()
    {
        Destroy(this.gameObject);
    }
}
