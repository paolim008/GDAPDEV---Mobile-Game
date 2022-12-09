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
        PlayerData.Instance.UpgradeHealth = 3;
        PlayerData.Instance.MaxHealth = PlayerData.Instance.BaseHealth + (10 * PlayerData.Instance.UpgradeHealth);
        UpdateUI();
    }
    public void MaxReload()
    {
        PlayerData.Instance.UpgradeReloadTime = 3;
        //Add ReloadTime Fix
        UpdateUI();
    }
    public void MaxShield()
    {
        PlayerData.Instance.UpgradeShield = 3;
        PlayerData.Instance.MaxShield = PlayerData.Instance.BaseShield + (PlayerData.Instance.UpgradeShield);
        UpdateUI();
    }
    public void AddCoins()
    {
        PlayerData.Instance.Coins += 10;
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
        PlayerData.Instance.Coins = 0;
         UpdateUI();
    }
    public void ResetHealth()
    {
        PlayerData.Instance.MaxHealth = 10;
        UpdateUI();
    }
    public void ResetShield()
    {
        PlayerData.Instance.MaxShield = 3;
         UpdateUI();
    }
    public void ResetHealthUpgrade()
    {
        PlayerData.Instance.UpgradeHealth = 0;
         UpdateUI();
    }
    public void ResetReloadUpgrade()
    {
        PlayerData.Instance.UpgradeReloadTime = 0;
         UpdateUI();
    }
    public void ResetShieldUpgrade()
    {
        PlayerData.Instance.UpgradeShield = 0;
         UpdateUI();
    }
    public void ResetTutorial()
    {
         playerData.hasPlayedTutorial = false;
         UpdateUI();
    }

    private void UpdateUI()
    {
        statsText[0].text = $"{PlayerData.Instance.UpgradeHealth} / 3";
        statsText[4].text = $"{PlayerData.Instance.UpgradeHealth} / 3";
        statsText[1].text = $"{PlayerData.Instance.UpgradeReloadTime} / 3";
        statsText[5].text = $"{PlayerData.Instance.UpgradeReloadTime} / 3";
        statsText[2].text = $"{PlayerData.Instance.UpgradeShield} / 3";
        statsText[6].text = $"{PlayerData.Instance.UpgradeShield} / 3";
        statsText[3].text = $"{PlayerData.Instance.Coins}";
        statsText[7].text = $"{PlayerData.Instance.Coins}";

    }
}
