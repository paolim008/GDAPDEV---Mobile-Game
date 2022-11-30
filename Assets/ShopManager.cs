using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private Player playerData;
    [SerializeField] private TextMeshProUGUI[] upgradeLevelText;
    [SerializeField] private TextMeshProUGUI coinsAmount;
    [SerializeField] private Button ConfirmButton;

    //Usable Data
    [SerializeField] private float coins;
    private int upgrade_Health;
    private int upgrade_ReloadTime;
    private int upgrade_Shields;
    
    //InitialData
    private float init_Coins;
    private int init_Health;
    private int init_ReloadTime;
    private int init_Shields;

    private int dataDifference;

    void Awake()
    {
        LoadData();
        SaveInitData();
        UpdateUI();
    }
    private void LoadData()
    {
        coins = playerData.coins;
        upgrade_Health = playerData.upgradeHealth;
        upgrade_ReloadTime = playerData.upgradeReloadTime;
        upgrade_Shields = playerData.upgradeShields;
    }

    private void SaveInitData()
    {
        init_Coins = coins;
        init_Health = upgrade_Health;
        init_ReloadTime = upgrade_ReloadTime;
        init_Shields = upgrade_Shields;
    }

    public void UpgradeHealth()
    {
        if (upgrade_Health < 3 && coins > 0)
        {
            coins--;
            upgrade_Health++;
            upgradeLevelText[0].color = Color.yellow;
        }
            
        UpdateUI();
    }
    public void UpgradeReloadTime()
    {
        if (upgrade_ReloadTime < 3 && coins > 0)
        {
            coins--;
            upgrade_ReloadTime++;
            upgradeLevelText[1].color = Color.yellow;
        }

        UpdateUI();
    }
    public void UpgradeShields()
    {
        if (upgrade_Shields < 3 && coins > 0)
        {
            coins--;
            upgrade_Shields++;
            upgradeLevelText[2].color = Color.yellow;
        }
        UpdateUI();
    }

    public void ResetHealth()
    {
        dataDifference = upgrade_Health - init_Health;
        coins += dataDifference;
        upgrade_Health = init_Health;
        upgradeLevelText[0].color = Color.white;
        UpdateUI();
    }
    public void ResetReloadTime()
    {
        dataDifference = upgrade_ReloadTime - init_ReloadTime;
        coins += dataDifference;
        upgrade_ReloadTime = init_ReloadTime;
        upgradeLevelText[1].color = Color.white;
        UpdateUI();
    }
    public void ResetShields()
    {
        dataDifference = upgrade_Shields - init_Shields;
        coins += dataDifference;
        upgrade_Shields = init_Shields;
        upgradeLevelText[2].color = Color.white;
        UpdateUI();
    }


    private void UpdateUI()
    {
        if (coins == init_Coins)
            ConfirmButton.interactable = false;
        else
            ConfirmButton.interactable = true;        
        
        upgradeLevelText[0].text = $"Level {upgrade_Health} / 3";
        upgradeLevelText[1].text = $"Level {upgrade_ReloadTime} / 3";
        upgradeLevelText[2].text = $"Level {upgrade_Shields} / 3";
        coinsAmount.text = $"Coins: {coins.ToString()}";
    }

    public void SaveData()
    {
        playerData.coins = coins;
        playerData.upgradeHealth = upgrade_Health;
        playerData.upgradeReloadTime = upgrade_ReloadTime;
        playerData.upgradeShields = upgrade_Shields;



        SaveInitData();
        //init_Coins = coins;

        for (int i = 0; i < upgradeLevelText.Length; i++)
            upgradeLevelText[i].color = Color.white;
    }

}
