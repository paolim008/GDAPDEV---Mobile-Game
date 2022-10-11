using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelAreaManager : MonoBehaviour
{
    private int levelStage;
    [SerializeField] private GameObject[] EndGamePanel;
    [SerializeField] private Transform EnemyHolder;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (EnemyHolder.childCount <= 0)
        {
            EndGamePanel[1].SetActive(true);
        }
    }
}
