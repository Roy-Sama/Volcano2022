using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int _seed;
    public Text _seedTxt;
    public int _star;
    public Text _starTxt;

    public static GameManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Il y a plus d'une instance de GameManager dans la scène");
            return;
        }

        instance = this;
    }

    void Start()
    {
        _seed = 0;
        _star = 0;
    }

    void Update()
    {

        _seedTxt.text = _seed.ToString();

        if (_star == 2)
        {
            NextLevel();
        }
    }

    public void NextLevel()
    {

    }
}
