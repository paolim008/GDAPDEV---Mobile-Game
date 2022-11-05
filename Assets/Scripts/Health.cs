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
        healthSlider.value = startingHealth;
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
        currentHealth -= _damage;
        healthSlider.value = currentHealth;
    }

    public void SetMaxHealth(float health)
    {
        maxHealth = health;
        currentHealth = maxHealth;
    }
}
