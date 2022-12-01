using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float startingHealth;
    [SerializeField] private float currentHealth;
    [SerializeField] private Slider healthSlider;
    private float maxHealth;

    private Shield playerShield;

    // Start is called before the first frame update
    void Start()
    {
        if (this.CompareTag("Enemy"))
        {
            currentHealth = startingHealth;
            maxHealth = startingHealth;
        }
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;

        //Get Shield Component if it exists
        //TryGetComponent<Shield>(out Shield playerShield);
        playerShield = GetComponent<Shield>();
        


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
        //Take half damage while blocking
        //if (GestureManager.Instance.IsBlocking() && playerShield.GetCurrentShields() > 0)
        if (Input.GetKey(KeyCode.Space) && playerShield.GetCurrentShields() > 0)
        {
            if (currentHealth > 0)
            {
                currentHealth -= _damage * .5f;
                playerShield.TakeShieldDamage(1);
            }

        }
        //Take full damage when not blocking
        else                                       
        {   
            currentHealth -= _damage;
            healthSlider.value = currentHealth;
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
