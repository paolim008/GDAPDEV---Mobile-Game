using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyAi : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] public int id;
    [SerializeField] private float damage = 10;
    [SerializeField] private GameObject spawnParticles;
    [SerializeField] private GameObject LExplosion;
    private Animator anim;

    private ScoreManager scoreManager;

    [SerializeField] 
    [Range(4,10)]
    private float attackCooldown;

    private bool onCooldown = false;

    void OnEnable()
    {
        Instantiate(spawnParticles, this.transform);
    }
    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
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
        StartCoroutine(DestroyObject());

    }

    IEnumerator DestroyObject()
    {
        anim.SetBool("Open_Anim", false);
        yield return new WaitForSeconds(1f);
        Instantiate(LExplosion, this.transform.position, this.transform.rotation);
        Destroy(gameObject);
        scoreManager.AddScore(1);
    }

    IEnumerator DealDamage(float damage)
    {
        onCooldown = true;

        attackCooldown = Random.Range(5, 10);
        yield return new WaitForSeconds(attackCooldown);
        anim.SetBool("Walk_Anim", true);
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("Walk_Anim", false);
        player.GetComponent<Health>().TakeDamage(damage);

        onCooldown = false;

        StopAllCoroutines();
    }

    public float GetCooldown()
    {
        return attackCooldown;
    }

}
