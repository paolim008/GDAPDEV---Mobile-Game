using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HudDisplay : MonoBehaviour
{
    [Header("Player Attributes")]
    [SerializeField] private GameObject player;
    [SerializeField] private Player playerData;

    [Header("Health")]
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Image healthSliderImage;

    [Header("Score")]
    [SerializeField] private TextMeshProUGUI scoreText;

    [Header("Weapon")]
    [SerializeField] private Image[] weaponSprites;

    private TextMeshProUGUI healthSliderText;
    private float score;
    private int currentWeapon;
    private string scoreString;

    private ScoreManager scoreManager;


    void Start()
    {
        scoreString = "";
        scoreManager = FindObjectOfType<ScoreManager>();
        LoadData();
        healthSliderText = healthSlider.GetComponentInChildren<TextMeshProUGUI>();
        healthSlider.maxValue = player.GetComponent<Health>().GetMaxHealth();
        healthSlider.value = player.GetComponent<Health>().GetCurrentHealth();


    }


    void Update()
    {
        //LoadData();

        EnableFill();

        healthSlider.value = player.GetComponent<Health>().GetCurrentHealth();
        healthSliderText.text = healthSlider.value.ToString() + " / " + healthSlider.maxValue.ToString();

        //scoreText.text = score.ToString();
        scoreText.text = scoreManager.GetScore().ToString();

        UpdateCurrentWeapon();
        for (int i = 0; i < weaponSprites.Length; i++)
        {
            if (i != currentWeapon)
            {
                weaponSprites[i].color = Color.white;
            }
            else
            {
                switch(i)
                {
                    case 0: weaponSprites[i].color = Color.blue;
                        break;                    
                    case 1: weaponSprites[i].color = Color.yellow;
                        break;                    
                    case 2: weaponSprites[i].color = Color.green;
                        break;                    
                    case 3: weaponSprites[i].color = Color.red;
                        break;
                }
            }


        }

    }

    private void EnableFill()
    {
            if(healthSlider.value <= healthSlider.minValue)
                healthSliderImage.enabled = false;
        
            if (healthSlider.value > healthSlider.minValue)
                healthSliderImage.enabled = true;
            
    }

    private void LoadData()
    {
        score = playerData.score;
    }

    private void UpdateCurrentWeapon()
    {
        currentWeapon = playerData.weaponType;
    }


}
