using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAi : MonoBehaviour
{
    [SerializeField] private int id;
    private float health;
    private float maxHealth = 8;
    private float attackInterval;
    private float attackquantity;
    private float attackquantityInterval;

    [SerializeField] Slider slider;
    // Start is called before the first frame update
    void Awake()
    {
        switch (id)
        {
            case 0: //Blue Enemy
                this.maxHealth = 8; 
                this.GetComponent<Renderer>().material.color = Color.blue; //Blue
                this.attackInterval = 2f;
                //this.GetComponent<Transform>().localScale = new Vector3(1f, 1f, 1f);
                break;
            case 1: 
                this.maxHealth = 16; 
                this.GetComponent<Renderer>().material.color = Color.yellow; //Yellow
                this.attackInterval = 1f;
                //this.GetComponent<Transform>().localScale = new Vector3(1.5f, 1.5f, 1.5f);
                break;
            case 2: 
                this.maxHealth = 25; 
                this.GetComponent<Renderer>().material.color = Color.red;//Red
                this.attackInterval = 3f;
                //this.GetComponent<Transform>().localScale = new Vector3(2f, 2f, 2f);
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
