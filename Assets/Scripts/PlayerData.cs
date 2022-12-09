using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{

    class PlayerInfo
    {
        string name;
        int BaseHealth, MaxHealth, BaseShield, MaxShield, WeaponType, Score, BaseReloadTime, ReloadMultiplier, Coins;
        
        class Upgrades
        {
            int UpgradeHealth, UpgradeReloadTime, UpgradeShields;
        }

        class Settings
        {
            bool MusicMute, SfxMute;
            float MusicVolume, SfxVolume;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
