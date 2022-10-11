using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private int weaponType;
    private float health;
    private float maxHealth;
    [SerializeField] private GameObject[] EndGamePanel;
    [SerializeField] private Slider healthBarSlider;
    [SerializeField] private TextMeshProUGUI WeaponText;
    [SerializeField] private GameObject[] equippedWeapon;

    // Start is called before the first frame update
    void Start()
    {
        this.weaponType = 1;
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
    }

    private void TakeInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) weaponType--;
            if (weaponType < 0) weaponType = equippedWeapon.Length - 1;
           
            
        if (Input.GetKeyDown(KeyCode.RightArrow)) weaponType++;
            if (weaponType > equippedWeapon.Length - 1) weaponType = 0;
    }
    private void SwitchWeapon(int activeWeapon)
    {
        for (int i = 0; i < equippedWeapon.Length; i++)
        {
            if (i != activeWeapon) equippedWeapon[i].SetActive(false);
            else equippedWeapon[i].SetActive(true);
        }
    }

    public void TakeDamage(float damage)
    {
        this.health -= damage;

        //Player Dies
        if (this.health <= 0f)
            EndGamePanel[0].SetActive(true);
    }
}
