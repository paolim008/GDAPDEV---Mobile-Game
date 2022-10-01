using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuHandler : MonoBehaviour
{
    [SerializeField] private GameObject[] MenuPanels;

    public enum Scenes
    {
        MainMenu,
        Tutorial,
        PlayGame,
        LevelSelect,
        Settings,
        Leaderboard
    };

    // Start is called before the first frame update
    void Start()
    {
        //Lists Current Scenes
        for (int i = 0; i < Scenes.GetNames(typeof(Scenes)).Length; i++)
        {
            Debug.Log((Scenes)i);
        }
        //Lists Total Number of scenes
        Debug.Log($"Total Scenes: {Scenes.GetNames(typeof(Scenes)).Length}");

        
        
    }


    // Update is called once per frame
    void Update()
    {

    }

    public void OnButtonClick()
    {
        //switch (GameObject.)
        //{
        //    case Scenes.MainMenu: Debug.Log("MainMenu");
        //        break;            
        //    case Scenes.Tutorial: Debug.Log("Tutorial");
        //        break;            
        //    case Scenes.PlayGame: Debug.Log("PlayGame");
        //        break;
        //}
    }

}
