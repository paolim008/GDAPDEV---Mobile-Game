using UnityEngine;
using TMPro;

public class StartBtn : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI buttonTxt;
    private bool shouldStart = true;

    public void OnPress()
    {
        if (shouldStart)
        {
            GameManager.Instance.PlayGame();
            buttonTxt.SetText("Stop");
            shouldStart = false;
        }
        else 
        { 
            GameManager.Instance.ResetGame();
            buttonTxt.SetText("Start");
            shouldStart = true;
        }
    }
}
