using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyAi : MonoBehaviour
{
    [SerializeField] private Player playerdata;
    [SerializeField] private GameObject player;
    [SerializeField] public int id;
    [SerializeField] private float damage = 10;
    [SerializeField] private float attackCooldown;

    private bool onCooldown = false;

    private float health;
    private float maxHealth = 8;

    [SerializeField] Slider healthSlider;
    // Start is called before the first frame update
    void Awake()
    {
        switch (id)
        {
            case 0: //Blue Enemy
                this.maxHealth = 8; 
                this.GetComponent<Renderer>().material.color = Color.blue; //Blue

                //this.GetComponent<Transform>().localScale = new Vector3(1f, 1f, 1f);
                break;
            case 1: 
                this.maxHealth = 16; 
                this.GetComponent<Renderer>().material.color = Color.yellow; //Yellow

                //this.GetComponent<Transform>().localScale = new Vector3(1.5f, 1.5f, 1.5f);
                break;
            case 2: 
                this.maxHealth = 25; 
                this.GetComponent<Renderer>().material.color = Color.red;//Red

                //this.GetComponent<Transform>().localScale = new Vector3(2f, 2f, 2f);
                break;
            default: return;
        }
        this.health = this.maxHealth;



    }

    // Update is called once per frame
    void Update()
    {
        if(!onCooldown)
        StartCoroutine(DealDamage(damage));



    }

    public void TakeDamage(float damage)
    {
        this.health -= damage;
        Debug.Log($"Name: {this.name} HP: {this.health}");
        this.healthSlider.value = this.health / this.maxHealth;

        if (this.health <= 0) DestroyEnemy();
    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);
        playerdata.score += 1;
    }

    IEnumerator DealDamage(float damage)
    {
        onCooldown = true;
            attackCooldown = Random.Range(5, 10);
            yield return new WaitForSeconds(attackCooldown);
            player.GetComponent<Health>().TakeDamage(damage);
        onCooldown = false;

        StopAllCoroutines();
    }



}
