using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    [SerializeField] private float currentHealth;
    private float maxHealth;


    // Start is called before the first frame update
    void Awake()
    {
        currentHealth = startingHealth;
        maxHealth = startingHealth;
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
    }
}
