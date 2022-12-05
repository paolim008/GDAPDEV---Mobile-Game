using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelAreaManager : MonoBehaviour
{
    [Header("Level Data")]
    [SerializeField] private LevelData levelData;
    private int levelStage;

    [Header("Player")]
    [SerializeField] private GameObject player;

    [Header("Enemy")]
    [SerializeField] private Transform enemyHolder;

    [Header("LevelTimer")]
    [SerializeField] private Timer_Script timerScript;

    [Header("EndScreen UI")]
    [SerializeField] private GameObject[] endGamePanel;
    [SerializeField] private TextMeshProUGUI[] scoreTMP;
    [SerializeField] private TextMeshProUGUI[] highScoreTMP;


    private ScoreManager scoreManager;
    private float _score;
    private float _highScore;

    void Awake()
    {
        _highScore = levelData.GetHighScore();
        scoreManager = FindObjectOfType<ScoreManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        levelStage = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (endGamePanel[3].activeSelf)
        {
            SaveHighScore();
            return;
        }

        _score = scoreManager.GetScore();
        
        //Display Death Screen
        if (player.GetComponent<Health>().GetCurrentHealth() <= 0)
        {
            OpenPanel(2);

            Time.timeScale = 0;
        }

        //Time Out
        else if (timerScript.GetCurrentTime() <= 0)
        {
            //Display TimeOutScreen
            OpenPanel(1);

        }



        if (Input.GetKeyDown(KeyCode.O))
            player.GetComponent<Health>().Heal(30);


            

    }


    public void ResetStats()
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
        if (_score > levelData.GetHighScore())
        {
            levelData.highScore = _score;
        }
    }

    public int GetLevelStage()
    {
        //Debug.Log($"level stage : {levelStage}");
        return levelStage;
    }    
    public void LoadLevelStage()
    {
        timerScript.ResetTimer();
        levelStage += 1;
    }

    public void OpenPanel(int panelIndex)
    {
        //Update Panel Data
        UpdatePanelData();
        //Close Current Panels
        foreach (GameObject panel in endGamePanel)
        {
            if(panel.activeSelf)
                panel.SetActive(false);
        }

        if(!endGamePanel[panelIndex].activeSelf)
            endGamePanel[panelIndex].SetActive(true);
        TimeScale(0);
    }

    public void OpenLoadingPanel(bool _status)
    {
        if(endGamePanel[0].activeSelf != _status)
            endGamePanel[0].SetActive(_status);
    }

    private void UpdatePanelData()
    {
        foreach (TextMeshProUGUI scoreText in scoreTMP)
        {
            scoreText.text = "Score: " + _score.ToString();
        }

        //foreach (TextMeshProUGUI highScoreText in highScoreTMP)
        //{
        //    if (score > _highScore){
        //        _highScore = _score;
        //        highScoreText.text = "Highscore: " + _highScore.ToString();
        //    }
        //}

    }

    public void TimeScale(int status)
    {
        Time.timeScale = status;
    }
}
