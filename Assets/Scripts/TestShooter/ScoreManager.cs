using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Player playerData;
    public static ScoreManager instance { get; private set; }
    private float _score;
    

    private void Awake()
    {
        instance = this;

        //Keep object when switching scenes
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        //Destroy duplicate
        else if (instance != null & instance != this)
        {
            Destroy(gameObject);
        }

    }

    public void AddScore()
    {

    }

}

