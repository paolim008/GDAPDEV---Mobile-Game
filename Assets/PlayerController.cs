using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Player playerdata;
    private int weaponType;
    private float health;
    private float maxHealth;
    //Take from NavScript
    public bool allowPlayerInput;
    [SerializeField] private TextMeshProUGUI weaponText;
    [SerializeField] private GameObject[] equippedWeapon;

    // Start is called before the first frame update
    void Start()
    {
        //this.allowPlayerInput = playerdata.allowPlayerInput;
        this.allowPlayerInput = true;
        this.weaponType = 0;
        this.maxHealth = 100;
        this.health = this.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(allowPlayerInput)
            TakeInput();

        SwitchWeapon(weaponType);
        this.weaponText.text = weaponType.ToString();

        SaveData();
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

    private void SaveData()
    {
        playerdata.health = this.health;
        playerdata.maxHealth = this.health;
        playerdata.weaponType = this.weaponType;
    }
}
