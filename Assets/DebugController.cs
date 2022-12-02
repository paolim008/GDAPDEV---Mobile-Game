using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugController : MonoBehaviour
{
    [SerializeField] private GameObject debugWindow;

    [SerializeField] private Player playerData;

    private bool status;

    void Awake()
    {
        status = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tilde))
        {
            ToggleDebugWindow();
        }

    }

    public void ToggleDebugWindow()
    {
        status = !status;
        debugWindow.SetActive(status);
    }

    public void MaxHealth()
    {
        playerData.upgradeHealth = 3;
        playerData.maxHealth = playerData.baseHealth + (10 * playerData.upgradeHealth);
    }
    public void MaxReload()
    {
        playerData.upgradeReloadTime = 3;
        //Add ReloadTime Fix
    }
    public void MaxShield()
    {
        playerData.upgradeShields = 3;
        playerData.maxShield = playerData.baseShield + (playerData.upgradeShields);
    }
    public void AddCoins()
    {
        playerData.coins += 10;
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
    }
    public void ResetCoins()
    {
         playerData.coins = 0;
    }
    public void ResetHealth()
    {
        playerData.maxHealth = 10;
    }
    public void ResetShield()
    {
         playerData.maxShield = 3;
    }
    public void ResetHealthUpgrade()
    {
         playerData.upgradeHealth = 0;
    }
    public void ResetReloadUpgrade()
    {
         playerData.upgradeReloadTime = 0;
    }
    public void ResetShieldUpgrade()
    {
         playerData.upgradeShields = 0;
    }
    public void ResetTutorial()
    {
         playerData.hasPlayedTutorial = false;
    }

}
