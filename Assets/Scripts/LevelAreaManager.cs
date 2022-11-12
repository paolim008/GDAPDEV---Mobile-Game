using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using GameObject = UnityEngine.GameObject;

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
        //Display Death Screen
        if (player.GetComponent<Health>().GetCurrentHealth() <= 0)
        {
            OpenPanel(2);

            Time.timeScale = 0;
        }

        //Time Out
        else if (timer.value <= .5)
        {
            //Display TimeOutScreen
            OpenPanel(1);

        }



        if (Input.GetKeyDown(KeyCode.O))
            player.GetComponent<Health>().Heal(30);

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

    public void OpenPanel(int panelIndex)
    {
        //Close Current Panels
        foreach (GameObject panel in endGamePanel)
        {
            if(panel.activeSelf)
                panel.SetActive(false);
        }

        if(!endGamePanel[panelIndex].activeSelf)
            endGamePanel[panelIndex].SetActive(true);
    }

    public void OpenLoadingPanel(bool _status)
    {
        if(endGamePanel[0].activeSelf != _status)
            endGamePanel[0].SetActive(_status);
    }
}
