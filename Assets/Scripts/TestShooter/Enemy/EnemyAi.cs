using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;

public class EnemyAi : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Shield playerShield;
    [SerializeField] public int id;
    [SerializeField] private float damage = 10;
    [SerializeField] private GameObject spawnParticles;
    [SerializeField] private GameObject LExplosion;
    [SerializeField] private GameObject AExplosion;
    [SerializeField] private GameObject blockedParticle;
    [SerializeField] private Transform indicatorPos;
    
    private Animator anim;

    private ScoreManager scoreManager;

    Player currency;
    [SerializeField] private TextMeshProUGUI coinsAmount;

    [SerializeField] 
    [Range(4,10)]
    private float attackCooldown;

    private bool onCooldown = false;

    void OnEnable()
    {
        Instantiate(spawnParticles, this.transform);
        transform.LookAt(player.transform.position);
        playerShield = player.GetComponent<Shield>();
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
        AudioManager.instance.Play("Enemy_Death");
        GameObject deathParticle = Instantiate(LExplosion, this.transform.position, this.transform.rotation);
        Destroy(deathParticle, 2);
        Destroy(gameObject);
        scoreManager.AddScore(1);
        currency.coins += 1;

        coinsAmount.text = currency.coins.ToString(); 
    }

    IEnumerator DealDamage(float damage)
    {
        onCooldown = true;

        attackCooldown = Random.Range(5, 10);
        yield return new WaitForSeconds(attackCooldown);
        anim.SetBool("Walk_Anim", true);
        if (playerShield.GetCurrentShields() == 0 || !GestureManager.Instance.IsBlocking())
        {
            AudioManager.instance.Play("Enemy_Attack");
            GameObject attackParticle = Instantiate(AExplosion, this.transform.position, this.transform.rotation);
            Destroy(attackParticle, 2f);
        }
        else
        {
            if (playerShield.GetCurrentShields() > 0)
            {
                GameObject blockedSpriteIndicator = Instantiate(blockedParticle, indicatorPos.position, this.transform.rotation);
                Destroy(blockedSpriteIndicator, 2f);
            }

        }
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
