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

    private ScoreManager scoreManager;

    [SerializeField] 
    [Range(4,10)]
    private float attackCooldown;

    private bool onCooldown = false;


    // Start is called before the first frame update
    void Awake()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
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
        scoreManager.AddScore(1);
        
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
