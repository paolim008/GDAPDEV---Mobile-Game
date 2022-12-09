using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Input = UnityEngine.Input;

public class Health : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float startingHealth;
    [SerializeField] private float currentHealth;
    [SerializeField] private Slider healthSlider;
    private float maxHealth;

    private Shield playerShield;
    [SerializeField] private bool shieldIsActive;

    // Start is called before the first frame update
    void Start()
    {
        if (this.CompareTag("Enemy"))
        {
            maxHealth = startingHealth;
            currentHealth = startingHealth;
        }
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;

        //Get Shield Component if it exists
        //TryGetComponent<Shield>(out Shield playerShield);
        playerShield = GetComponent<Shield>();

        shieldIsActive = false;

        currentHealth = maxHealth;
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
        shieldIsActive = GestureManager.Instance.IsBlocking();

        //Take half damage while blocking
        //if (GestureManager.Instance.IsBlocking() && playerShield.GetCurrentShields() > 0)
        if (shieldIsActive && playerShield.GetCurrentShields() > 0)
        {
            if (currentHealth > 0)
            {
                currentHealth -= _damage * .5f;
                playerShield.TakeShieldDamage(1);
                Debug.Log("Half Damage Taken", this);
            }

        }
        //Take full damage when not blocking
        else                                       
        {   
            currentHealth -= _damage;
            healthSlider.value = currentHealth;
            Debug.Log("Full Damage Taken", this);
        }

    }
    public void Heal(float _amount)
    {
        currentHealth += _amount;
        healthSlider.value = currentHealth;
    }

    public void SetMaxHealth(float health)
    {
        maxHealth = health;
        currentHealth = maxHealth;
    }

    
}
