using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HudDisplay : MonoBehaviour
{
    public Player playerdata;
    [SerializeField] private GameObject[] EndGamePanel;
    [SerializeField] private Slider healthBarSlider;
    [SerializeField] private TextMeshProUGUI healthBarValue;
    [SerializeField] private TextMeshProUGUI weaponText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject[] equippedWeapon;

    private int score;

    private int weaponType;
    private float maxHealth;
    private float health;

    void Awake()
    {
        LoadData();
    }

    // Start is called before the first frame update
    void Start()
    {
        this.healthBarSlider.maxValue = this.maxHealth;
    }

    void Update()
    {
        LoadData();
        this.healthBarSlider.value = this.health;
        this.healthBarValue.text = this.health.ToString() + "/" + this.maxHealth;
        this.scoreText.text = score.ToString();
        this.weaponText.text = weaponType.ToString();

    }

    private void LoadData()
    {
        this.health = playerdata.health;
        this.maxHealth = playerdata.health;
        this.weaponType = playerdata.weaponType;
        this.score = playerdata.score;
    }

}
