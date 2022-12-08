using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Time = UnityEngine.Time;

[System.Serializable]
public class Timer_Script : MonoBehaviour
{
    private Image timerFillImage;
    [SerializeField] private float maxTimer = 10f;

    private Color timerColor;
    private float currTimer;
    private bool isActive;


    void Awake()
    {
        timerFillImage = GetComponent<Image>();
        SetTimer(10);
    }

    void Update()
    {
        if (currTimer < 0 && isActive) PauseTimer();

        //if (Input.GetKey(KeyCode.Space))
        //        ResetTimer();
        //if (Input.GetKeyDown(KeyCode.P))
        //        isActive = !isActive;

        UpdateFill();

        if (!isActive) return;
        
        currTimer -= Time.deltaTime;

    }

    public void ResetTimer()
    {
        currTimer = maxTimer;
    }

    public void PauseTimer()
    {
        isActive = false;
        Debug.Log("Timer is Paused", this);
    }
    public void ResumeTimer()
    {
        isActive = true;
        Debug.Log("Timer is Resumed", this);
    }
    public void SetTimer(float _maxTime)
    {
        maxTimer = _maxTime;
        ResetTimer();
        ResumeTimer();
    }

    public float GetCurrentTime() => currTimer;
    private void UpdateFill()
    {
        timerColor = new Color(1, timerFillImage.fillAmount, timerFillImage.fillAmount);
        timerFillImage.fillAmount = currTimer / maxTimer;
        timerFillImage.color = timerColor;
    }
}
