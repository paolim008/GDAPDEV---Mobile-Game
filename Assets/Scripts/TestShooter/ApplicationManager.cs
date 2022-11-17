using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationManager : MonoBehaviour
{
    public void OnQuitApplication()
    {
        Debug.Log("Application Quit");
        Application.Quit();
       
    }
}
