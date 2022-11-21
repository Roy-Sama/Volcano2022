using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] PorteDalle _porte;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            print("PlayerON");
            _animator.SetBool("inGround", true);
            _porte._animator.SetBool("activate", true);
            //sfx plaque de pression
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            print("PlayerOFF");
            StartCoroutine(resetTime(40f));
        }
    }

    IEnumerator resetTime(float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        _animator.SetBool("inGround", false);
        _porte._animator.SetBool("activate", false);
    }
}
