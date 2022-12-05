using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Time = UnityEngine.Time;

public class Timer_Script : MonoBehaviour
{
    private Image timerFillImage;
    [Tooltip("In Seconds")]
    [SerializeField] private float maxTimer;

    private Color timerColor;
    private float currTimer;
    private bool isActive;


    void Awake()
    {
        timerFillImage = GetComponent<Image>();
        ResetTimer();
        isActive = true;
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

    private void ResetTimer()
    {
        currTimer = maxTimer;
    }

    private void PauseTimer()
    {
        isActive = false;
        Debug.Log("Timer is Paused", this);
    }
    private void UpdateFill()
    {
        timerColor = new Color(1, timerFillImage.fillAmount, timerFillImage.fillAmount);
        timerFillImage.fillAmount = currTimer / maxTimer;
        timerFillImage.color = timerColor;
    }
}
