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

    //Component Initialization
    private Health playerHealth;
    private Shield playerShield;

    //Take from NavScript
    public bool allowPlayerInput;
    [SerializeField] private GameObject[] equippedWeapon;

    void Awake()
    {
        playerHealth = GetComponent<Health>();
        playerHealth.SetMaxHealth(playerdata.maxHealth);

        playerShield = GetComponent<Shield>();
        playerShield.SetMaxShield(playerdata.maxShield);
    }

    // Start is called before the first frame update
    void Start()
    {
        this.allowPlayerInput = true;
        this.weaponType = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (allowPlayerInput)
        {
            TakeGestureInput();
        }
        TakeDebugInput();

        SwitchWeapon(weaponType);
        playerdata.weaponType = weaponType;
    }

    private void TakeGestureInput()
    {
        if (GestureManager.Instance.SwitchingLeft())    // checks if swipe was for left
        {
            weaponType--;
            GestureManager.Instance.SetSingle();        // allows single fire only
            GestureManager.Instance.ToggleLeft();
        }

        if (weaponType < 0)
            weaponType = equippedWeapon.Length - 1;


        if (GestureManager.Instance.SwitchingRight())   // checks if swipe was for right
        {
            weaponType++;
            GestureManager.Instance.SetSingle();         // allows for rapid fire
            GestureManager.Instance.ToggleRight();
        }

        if (weaponType > equippedWeapon.Length - 1)
            weaponType = 0;
    }

    private void TakeDebugInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) 
        {
            weaponType--;
        }

        if (weaponType < 0)
            weaponType = equippedWeapon.Length - 1;


        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            weaponType++;
        }

        if (weaponType > equippedWeapon.Length - 1)
            weaponType = 0;

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
