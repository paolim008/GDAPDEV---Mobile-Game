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


    [SerializeField] 
    [Range(4,10)]
    private float attackCooldown;


    [SerializeField] private Slider attackSlider;

    private bool onCooldown = false;


    // Start is called before the first frame update
    void Awake()
    {
        switch (id)
        {
            case 0: //Blue Enemy
                this.GetComponent<Health>().SetMaxHealth(8);
                this.GetComponent<Renderer>().material.color = Color.blue; //Blue

                //this.GetComponent<Transform>().localScale = new Vector3(1f, 1f, 1f);
                break;
            case 1: 
                this.GetComponent<Health>().SetMaxHealth(16);
                this.GetComponent<Renderer>().material.color = Color.yellow; //Yellow

                //this.GetComponent<Transform>().localScale = new Vector3(1.5f, 1.5f, 1.5f);
                break;
            case 2: 
                this.GetComponent<Health>().SetMaxHealth(25);
                this.GetComponent<Renderer>().material.color = Color.red;//Red

                //this.GetComponent<Transform>().localScale = new Vector3(2f, 2f, 2f);
                break;
            default: return;
        }
        



    }

    // Update is called once per frame
    void Update()
    {
        //Enemy Attacks
        if(!onCooldown)
        StartCoroutine(DealDamage(damage));

    }

    public void TakeDamage(float damage)
    {
        //Damage Enemy
        this.GetComponent<Health>().TakeDamage(damage);
        //Destroy Enemy and Add Score
        if (this.GetComponent<Health>().GetCurrentHealth() <= 0) DestroyEnemy();
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

                if (!Input.GetKey(KeyCode.Space))
                {
                    player.GetComponent<Health>().TakeDamage(damage);
                    Debug.Log("BANG");
                }

        onCooldown = false;

        StopAllCoroutines();
    }

    public float GetCooldown()
    {
        return attackCooldown;
    }

}
