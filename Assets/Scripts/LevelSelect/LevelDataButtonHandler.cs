using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDataButtonHandler : MonoBehaviour
{
    [SerializeField] private LevelData levelData;
    private float highscore;
    // Start is called before the first frame update

    public void Initialize()
    {
        highscore = levelData.highScore;

        CallLeaderBoard(highscore);
    }

    private void CallLeaderBoard(float highscore)
    {

    }
}
