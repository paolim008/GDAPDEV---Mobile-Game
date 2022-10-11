using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAi : MonoBehaviour
{
    [SerializeField] private int id;
    private float health;
    private float maxHealth = 8;

    [SerializeField] Slider slider;
    // Start is called before the first frame update
    void Awake()
    {
        switch (id)
        {
            case 0: //Blue Enemy
                this.maxHealth = 8; 
                this.GetComponent<Renderer>().material.color = Color.blue; //Blue
                break;
            case 1: 
                this.maxHealth = 16; 
                this.GetComponent<Renderer>().material.color = Color.yellow; //Yellow
                break;
            case 2: 
                this.maxHealth = 25; 
                this.GetComponent<Renderer>().material.color = Color.red;//Red
                break;
            default: return;
        }
        this.health = this.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.health <= 0)
        {
            Destroy(gameObject);
        }

        
    }

    public void TakeDamage(int damage)
    {
        this.health -= damage;
        Debug.Log(this.health);
        this.slider.value = this.health / this.maxHealth;
    }
}
