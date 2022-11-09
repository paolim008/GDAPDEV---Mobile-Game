using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    [SerializeField] private float currentHealth;
    [SerializeField] private Slider healthSlider;
    private float maxHealth;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
        maxHealth = startingHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }


    // Update is called once per frame
    void Update()
    {

    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }    
    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public void TakeDamage(float _damage)
    {
        if (!PlayerActions.Instance.IsBlocking())     // cancels damage if player is blocking
        {
            currentHealth -= _damage;
            healthSlider.value = currentHealth;
        }
        else if (PlayerActions.Instance.IsParrying())   // awards 1 health for a successful parry if health isn't at max
        {
            if (currentHealth < maxHealth)
                currentHealth++;
        }
        else                                          // 1 damage if player health is above 1, and is blocking
        {
            if (currentHealth > 1)
                currentHealth -= 1;
        }
        
    }

    public void SetMaxHealth(float health)
    {
        maxHealth = health;
        currentHealth = maxHealth;
    }
}
