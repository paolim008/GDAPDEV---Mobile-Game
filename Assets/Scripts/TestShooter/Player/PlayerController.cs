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

    //Take from NavScript
    public bool allowPlayerInput;
    [SerializeField] private GameObject[] equippedWeapon;

    // Start is called before the first frame update
    void Start()
    {
        //this.allowPlayerInput = playerdata.allowPlayerInput;
        this.allowPlayerInput = true;
        this.weaponType = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if(allowPlayerInput)
            TakeInput();

        SwitchWeapon(weaponType);
        playerdata.weaponType = weaponType;
    }

    private void TakeInput()
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
            GestureManager.Instance.SetRapid();         // allows for rapid fire
            GestureManager.Instance.ToggleRight();
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
