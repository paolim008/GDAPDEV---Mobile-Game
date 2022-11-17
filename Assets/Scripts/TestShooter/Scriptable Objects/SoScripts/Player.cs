using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayer", menuName = "Player")]
public class Player : ScriptableObject
{
    public new string name;
    public float maxHealth;
    public int weaponType;
    public int score;
    public float totalScore;

    public string GetName()
    {
        return name;
    }
    public float GetMaxHealth()
    {
        return maxHealth;
    }
    public void SetMaxHealth(float setHealth) => maxHealth = setHealth;

    

}
