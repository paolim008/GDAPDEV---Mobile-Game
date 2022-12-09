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
    
    [Header("Shields")]
    [SerializeField] private Slider shieldSlider;
    [SerializeField] private Image shieldSliderImage;
    [SerializeField] private GameObject shieldIndicator;
    

    [Header("Score")]
    [SerializeField] private TextMeshProUGUI scoreText;

    [Header("Weapon")]
    [SerializeField] private Image weaponSprite;
    [SerializeField] private TextMeshProUGUI weapontext;

    [SerializeField] private TextMeshProUGUI ammoText;

    private TextMeshProUGUI healthSliderText;
    private TextMeshProUGUI shieldSliderText;
    private float score;
    private int currentWeapon;
    //private string scoreString;

    private ScoreManager scoreManager;


    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        LoadData();
        //Health Slider Init
        healthSliderText = healthSlider.GetComponentInChildren<TextMeshProUGUI>();
        healthSlider.maxValue = player.GetComponent<Health>().GetMaxHealth();
        healthSlider.value = player.GetComponent<Health>().GetCurrentHealth();        
        
        //Shield Slider Init
        shieldSliderText = shieldSlider.GetComponentInChildren<TextMeshProUGUI>();
        shieldSlider.maxValue = player.GetComponent<Shield>().GetMaxShields();
        shieldSlider.value = player.GetComponent<Shield>().GetCurrentShields();

    }


    void Update()
    {
        //LoadData();
        ActivateShield(GestureManager.Instance.IsBlocking());

        EnableFill();

        healthSlider.value = player.GetComponent<Health>().GetCurrentHealth();
        healthSliderText.text = healthSlider.value.ToString() + " / " + healthSlider.maxValue.ToString();
        shieldSliderText.text = shieldSlider.value.ToString() + " / " + shieldSlider.maxValue.ToString();

        //scoreText.text = score.ToString();
        scoreText.text = scoreManager.GetScore().ToString();

        UpdateCurrentWeapon();

                switch(currentWeapon)
                {
                    case 0: weaponSprite.color = Color.blue;
                            ammoText.color = Color.blue;
                        break;                    
                    case 1: weaponSprite.color = Color.yellow;
                            ammoText.color = Color.yellow;
                        break;                    
                    case 2: weaponSprite.color = Color.green;
                            ammoText.color = Color.green;
                        break;                    
                    case 3: weaponSprite.color = Color.red;
                            ammoText.color = Color.red;
                        break;
                }

                weapontext.text = $"{currentWeapon + 1} / 4";



    }

    private void ActivateShield(bool status)
    {
        shieldIndicator.SetActive(status);
        //Debug.Log(status);
    }
    private void EnableFill()
    {
            if(healthSlider.value <= healthSlider.minValue)
                healthSliderImage.enabled = false;
        
            if (healthSlider.value > healthSlider.minValue)
                healthSliderImage.enabled = true;

            if(shieldSlider.value <= shieldSlider.minValue)
                shieldSliderImage.enabled = false;
        
            if (shieldSlider.value > shieldSlider.minValue)
                shieldSliderImage.enabled = true;
            
    }

    private void LoadData()
    {
        score = PlayerData.Instance.Score;
    }

    private void UpdateCurrentWeapon()
    {
        currentWeapon = playerData.weaponType;
    }

    public void UpdateUI()
    {
        healthSlider.value = PlayerData.Instance.MaxHealth;
        shieldSlider.value = PlayerData.Instance.MaxShield;
    }

}
