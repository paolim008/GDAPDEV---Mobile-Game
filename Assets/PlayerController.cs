using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Player playerdata;
    private int weaponType;
    private float health;
    private float maxHealth;
    public bool takePlayerInput;
    [SerializeField] private GameObject[] EndGamePanel;
    [SerializeField] private Slider healthBarSlider;
    [SerializeField] private TextMeshProUGUI healthBarValue;
    [SerializeField] private TextMeshProUGUI WeaponText;
    [SerializeField] private GameObject[] equippedWeapon;

    // Start is called before the first frame update
    void Start()
    {
        this.takePlayerInput = true;
        this.weaponType = 0;
        this.maxHealth = 100;
        this.health = this.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        TakeInput();
        SwitchWeapon(weaponType);
        WeaponText.text = weaponType.ToString();
        this.healthBarSlider.value = this.health / this.maxHealth;
        this.healthBarValue.text = this.health.ToString() + "/" + this.maxHealth;
    }

    private void TakeInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) weaponType--;
            if (weaponType < 0) weaponType = equippedWeapon.Length - 1;
           
            
        if (Input.GetKeyDown(KeyCode.RightArrow)) weaponType++;
            if (weaponType > equippedWeapon.Length - 1) weaponType = 0;

        //DebugMode
        if (Input.GetKeyDown(KeyCode.P))
                this.health -= 5;

    }
    private void SwitchWeapon(int activeWeapon)
    {
        for (int i = 0; i < equippedWeapon.Length; i++)
        {
            if (i != activeWeapon) equippedWeapon[i].SetActive(false);
            else equippedWeapon[i].SetActive(true);
        }
    }

}
