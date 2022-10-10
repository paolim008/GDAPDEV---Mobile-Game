using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAi : MonoBehaviour
{
    private float health;
    private float maxHealth = 8;

    [SerializeField] Slider slider;
    // Start is called before the first frame update
    void Awake()
    {
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
