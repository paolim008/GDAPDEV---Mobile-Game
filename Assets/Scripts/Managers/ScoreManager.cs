using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance { get; private set; }
    [SerializeField] private float score;
    

    private void Awake()
    {
        score = 0;
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

    public void AddScore(float points)
    {
        score += points;
    }

    public float GetScore()
    {
        return score;
    }

    public void ResetScore()
    {
        score = 0;
    }

    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.K))
    //        AddScore(15);
    //}

}

