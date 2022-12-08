using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DebugController : MonoBehaviour
{
    [SerializeField] private GameObject debugWindow;
    [SerializeField] private GameObject backButton;

    [SerializeField] private Player playerData;

    [SerializeField] private TextMeshProUGUI[] statsText;


    private bool status;

    void Awake()
    {
        status = debugWindow.activeSelf;
        UpdateUI();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ToggleDebugWindow();
        }

    }

    public void ToggleDebugWindow()
    {
        status = !status;
        debugWindow.SetActive(status);
        backButton.SetActive(status);
    }

    public void MaxHealth()
    {
        playerData.upgradeHealth = 3;
        playerData.maxHealth = playerData.baseHealth + (10 * playerData.upgradeHealth);
        UpdateUI();
    }
    public void MaxReload()
    {
        playerData.upgradeReloadTime = 3;
        //Add ReloadTime Fix
        UpdateUI();
    }
    public void MaxShield()
    {
        playerData.upgradeShields = 3;
        playerData.maxShield = playerData.baseShield + (playerData.upgradeShields);
        UpdateUI();
    }
    public void AddCoins()
    {
        playerData.coins += 10;
        UpdateUI();
    }

    public void ResetAllStats()
    {
        ResetCoins();
        ResetHealth();
        ResetHealthUpgrade();
        ResetReloadUpgrade();
        ResetShield();
        ResetShieldUpgrade();
        ResetTutorial();

        UpdateUI();
    }
    public void ResetCoins()
    {
         playerData.coins = 0;
         UpdateUI();
    }
    public void ResetHealth()
    {
        playerData.maxHealth = 10;
        UpdateUI();
    }
    public void ResetShield()
    {
         playerData.maxShield = 3;
         UpdateUI();
    }
    public void ResetHealthUpgrade()
    {
         playerData.upgradeHealth = 0;
         UpdateUI();
    }
    public void ResetReloadUpgrade()
    {
         playerData.upgradeReloadTime = 0;
         UpdateUI();
    }
    public void ResetShieldUpgrade()
    {
         playerData.upgradeShields = 0;
         UpdateUI();
    }
    public void ResetTutorial()
    {
         playerData.hasPlayedTutorial = false;
         UpdateUI();
    }

    private void UpdateUI()
    {
        statsText[0].text = $"{playerData.upgradeHealth} / 3";
        statsText[4].text = $"{playerData.upgradeHealth} / 3";
        statsText[1].text = $"{playerData.upgradeReloadTime} / 3";
        statsText[5].text = $"{playerData.upgradeReloadTime} / 3";
        statsText[2].text = $"{playerData.upgradeShields} / 3";
        statsText[6].text = $"{playerData.upgradeShields} / 3";
        statsText[3].text = $"{playerData.coins}";
        statsText[7].text = $"{playerData.coins}";

    }
}
