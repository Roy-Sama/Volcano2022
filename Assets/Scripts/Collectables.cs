using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    [SerializeField] bool _isStars;
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!_isStars)
            {
                GameManager.instance._seed++;
                Destroy(this.gameObject);
            }

            if (_isStars)
            {
                GameManager.instance._star++;
                Destroy(this.gameObject);
            }

        }
    }
}
