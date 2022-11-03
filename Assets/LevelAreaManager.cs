using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelAreaManager : MonoBehaviour
{
    private int levelStage;
    private int score;
    [SerializeField] private GameObject[] endGamePanel;
    [SerializeField] private TextMeshProUGUI scoretext;
    [SerializeField] private GameObject player;
    [SerializeField] private Transform enemyHolder;
    [SerializeField] private Slider timer;

    



    // Start is called before the first frame update
    void Start()
    {
        levelStage = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //Display Game Over Screen
        if (player.GetComponent<Health>().GetCurrentHealth() <= 0)
        {
            Debug.Log("Player Died");
            endGamePanel[1].SetActive(true);
            Time.timeScale = 0;

        }


        //Load Next Area
        if (enemyHolder.childCount <= 0 || timer.value <= 0 + .01)
        {
            endGamePanel[0].SetActive(true);
        }

        
    }


    void ResetStats()
    {
        levelStage = 1;

        //Close all endGamePanels
        for(int i = 0; i < endGamePanel.Length; i++)
        {
            endGamePanel[i].SetActive(false);
        }


        
    }


    void SaveHighScore()
    {
        //if (this.score > playerdata.score)
        //{
        //    //Add Feature: Display New HighScore on EndgamePanel
        //    playerdata.score = this.score;
        //}
    }
}
