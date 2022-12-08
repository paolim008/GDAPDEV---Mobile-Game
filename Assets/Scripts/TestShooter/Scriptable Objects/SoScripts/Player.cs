using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayer", menuName = "Player")]
public class Player : ScriptableObject
{
    public new string name;
    public float baseHealth;
    public float maxHealth;    
    public float baseShield;
    public float maxShield;
    public int weaponType;
    public int score;

    public float baseReloadTime;
    public float reloadMultiplier;
    //public float totalScore;
    public int coins;
    public bool hasPlayedTutorial = false;

    [Header("Upgrades")] 
    public int upgradeHealth;
    public int upgradeReloadTime;
    public int upgradeShields;

    [Header("Settings")] 
    public bool musicMute;
    public bool sfxMute;
    public float musicVolume;
    public float sfxVolume;

    public string GetName()
    {
        return name;
    }
    public float GetMaxHealth()
    {
        return maxHealth;
    }
    public void SetMaxHealth(float setHealth) => maxHealth = setHealth;

    public void TutorialIsDone() => hasPlayedTutorial = true;

    public void SaveSettings(bool _musicMute, bool _sfxMute, float _musicVolume, float _sfxVolume)
    {
        musicMute = _musicMute;
        sfxMute = _sfxMute;
        musicVolume = _musicVolume;
        sfxVolume = _sfxVolume;
    }
}
