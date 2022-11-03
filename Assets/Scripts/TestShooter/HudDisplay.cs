using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HudDisplay : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Slider healthSlider;
    private TextMeshProUGUI healthSliderText;
    

    void Awake()
    {
        //LoadData();
        healthSliderText = healthSlider.GetComponentInChildren<TextMeshProUGUI>();
        healthSlider.maxValue = player.GetComponent<Health>().GetMaxHealth();
        healthSlider.value = player.GetComponent<Health>().GetCurrentHealth();

        
    }


    void Update()
    {
        healthSlider.value = player.GetComponent<Health>().GetCurrentHealth();
        healthSliderText.text = healthSlider.value.ToString() + " / " + healthSlider.maxValue.ToString();
        if (Input.GetKeyDown(KeyCode.P))
        {
            player.GetComponent<Health>().TakeDamage(10);
        }

    }

    private void LoadData()
    {

    }

}
