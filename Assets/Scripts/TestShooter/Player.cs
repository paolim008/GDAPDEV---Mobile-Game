using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayer", menuName = "Player")]
public class Player : ScriptableObject
{
    public new string name;
    public float maxHealth;
    public int weaponType;
    public int score;
    public bool allowPlayerInput;

}
