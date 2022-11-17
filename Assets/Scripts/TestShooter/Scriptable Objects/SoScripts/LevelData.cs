using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "LevelData")]
public class LevelData : ScriptableObject
{
    public float highScore;
    public float totalTime;

    public float GetHighScore()
    {
        return highScore;
    }
    public float GetTotalTime()
    {
        return totalTime;
    }


}