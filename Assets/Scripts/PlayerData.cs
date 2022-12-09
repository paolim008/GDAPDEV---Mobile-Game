using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    public string Name = "Rickshaw";
    public int BaseHealth = 10, MaxHealth = 10, BaseShield = 3, MaxShield = 3, WeaponType = 0, Score = 0, BaseReloadTime = 1, ReloadMultiplier = 0, Coins = 0;

    public int UpgradeHealth = 0, UpgradeReloadTime = 0, UpgradeShield = 0;

    public bool MusicMute = false, SfxMute = false;
    float MusicVolume = 0.5562919f, SfxVolume = 0.5715631f;

    private static PlayerData instance;
    public static PlayerData Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

}
