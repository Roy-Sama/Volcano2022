using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource _good;
    public AudioSource _bad;

    void Start()
    {
        _good.volume = 0f;
        _bad.volume = 1f;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            //VolumeChanger(1, 0);

            StartCoroutine(ChangeGoodVolume(0f, 1f, 2f));
            StartCoroutine(ChangeBadVolume(1f, 0f, 2f));
            print("MusicChange");
        }
    }

    //public void VolumeChanger(float volGood, float volBad)
    //{


    //    _good.volume = Mathf.Lerp(_good.volume, volGood, 1f);
    //    _bad.volume = Mathf.Lerp(_bad.volume, volBad, 1f);
    //}
    IEnumerator ChangeGoodVolume(float GoodA, float GoodB, float duration)
    {
    
        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            _good.volume = Mathf.Lerp(GoodA, GoodB, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        _good.volume = GoodB;
    }

    IEnumerator ChangeBadVolume(float BadA, float BadB, float duration)
    {

        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            _bad.volume = Mathf.Lerp(BadA, BadB, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        _bad.volume = BadB;
    }
}
