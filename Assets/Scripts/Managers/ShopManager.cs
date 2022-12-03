using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private Player playerData;

    [SerializeField] private TextMeshProUGUI[] upgradeLevelText;
    [SerializeField] private Button[] upgradeButtons;
    [SerializeField] private Button[] undoButtons;

    [SerializeField] private TextMeshProUGUI coinsAmount;
    [SerializeField] private Button ConfirmButton;

    private bool shouldDisplay;
    private bool insufficientFunds;

    //Usable Data
    [SerializeField] private int coins;
    private int upgrade_Health;
    private int upgrade_ReloadTime;
    private int upgrade_Shields;
    
    //InitialData
    private int init_Coins;
    private int init_Health;
    private int init_ReloadTime;
    private int init_Shields;

    private int dataDifference;

    void Awake()
    {
        LoadData();
        SaveInitData();
        CheckCoins();
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
            if (!undoButtons[0].interactable)
                undoButtons[0].interactable = true;
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

            if (!undoButtons[1].interactable)
                undoButtons[1].interactable = true;
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
            if (!undoButtons[2].interactable)
                undoButtons[2].interactable = true;
        }

        UpdateUI();
    }

    public void ResetHealth()
    {
        dataDifference = upgrade_Health - init_Health;
        coins += dataDifference;
        upgrade_Health = init_Health;
        upgradeLevelText[0].color = Color.white;
        if (undoButtons[0].interactable)
            undoButtons[0].interactable = false;

        UpdateUI();
    }
    public void ResetReloadTime()
    {
        dataDifference = upgrade_ReloadTime - init_ReloadTime;
        coins += dataDifference;
        upgrade_ReloadTime = init_ReloadTime;
        upgradeLevelText[1].color = Color.white;
        if (undoButtons[1].interactable)
            undoButtons[1].interactable = false;

        UpdateUI();
    }
    public void ResetShields()
    {
        dataDifference = upgrade_Shields - init_Shields;
        coins += dataDifference;
        upgrade_Shields = init_Shields;
        upgradeLevelText[2].color = Color.white;
        if (undoButtons[2].interactable)
            undoButtons[2].interactable = false;

        UpdateUI();
    }

    private void CheckCoins() // returns true if sufficientFunds
    {
        insufficientFunds = coins <= 0;
        if (insufficientFunds)
        {
            ChangeUpgradeButtonState(false);
            coinsAmount.color = Color.red;
        }
        else
        {
            ChangeUpgradeButtonState(true);
            coinsAmount.color = Color.white;
        }

    }

    private void ChangeUpgradeButtonState(bool state)
    {
        foreach (Button button in upgradeButtons)
                button.interactable = state;
    }

    private void UpdateUI()
    {
        CheckCoins();
        shouldDisplay = coins != init_Coins;
        ConfirmButton.interactable = shouldDisplay;

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

        playerData.maxHealth = playerData.baseHealth + (10 * upgrade_Health);
        playerData.reloadMultiplier = .25f * (float)upgrade_ReloadTime;
        playerData.maxShield = playerData.baseShield + (upgrade_Shields);


        SaveInitData();

        foreach (Button button in undoButtons)
            button.interactable = false;

        foreach (TextMeshProUGUI text in upgradeLevelText)
            text.color = Color.white;
    }

}
