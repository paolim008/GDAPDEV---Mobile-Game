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
            if(endGamePanel[0].activeSelf)
                endGamePanel[0].SetActive(false);
            endGamePanel[1].SetActive(true);
            
            Time.timeScale = 0;
        }

        //Load Next Area
        else if (timer.value <= 0 + .01)
        {
            //Close Player-Died Panel
            if (endGamePanel[1].activeSelf)
                endGamePanel[1].SetActive(false);

            //Open Loading-Next-Area Panel
            endGamePanel[0].SetActive(true);
            //levelStage++;
            timer.value = timer.maxValue;
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


    private void GetActiveEnemiesInArea()
    {

    }

    public int GetLevelStage()
    {
        Debug.Log($"level stage : {levelStage}");
        return levelStage;
    }    
    public void LoadLevelStage()
    {
        timer.value = timer.maxValue;
        levelStage += 1;
    }

    public float GetTimeLeft()
    {
        return timer.value;
    }

    public void DisplayEndScreen(int status)
    {
        if (player.GetComponent<Health>().GetCurrentHealth() <= 0)
        {
            Debug.Log("Player Died");
            if (endGamePanel[0].activeSelf)
                endGamePanel[0].SetActive(false);
            endGamePanel[1].SetActive(true);

            Time.timeScale = 0;
        }

    }
}
