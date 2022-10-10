using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int weaponType;
    [SerializeField] private TextMeshProUGUI WeaponText;
    [SerializeField] private GameObject[] equippedWeapon;

    // Start is called before the first frame update
    void Start()
    {
        this.weaponType = 1;
    }

    // Update is called once per frame
    void Update()
    {
        TakeInput();
        SwitchWeapon(weaponType);
        WeaponText.text = weaponType.ToString();


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
}
