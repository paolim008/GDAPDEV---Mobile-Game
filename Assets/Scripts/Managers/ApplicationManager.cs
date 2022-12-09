using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplicationManager : MonoBehaviour
{
    [SerializeField] private Player playerData;
    [SerializeField] private GameObject tutorialConfirm;
    public void OnQuitApplication()
    {
        Debug.Log("Application Quit");
        Application.Quit();
       
    }
    public void TutorialConfirm()
    {
        if (playerData.hasPlayedTutorial == false)
        {
            tutorialConfirm.gameObject.SetActive(true);
            playerData.TutorialIsDone();
        }
        else
        {
            SceneManager.LoadScene("First Level");
            playerData.TutorialIsDone();
        }


    }
}
