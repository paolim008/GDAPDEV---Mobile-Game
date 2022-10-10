using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAi : MonoBehaviour
{
    private float Health = 100;

    [SerializeField] Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.Health <= 0)
        {
            Destroy(gameObject);
        }

        
    }

    public void TakeDamage(int damage)
    {
        this.Health -= damage;
        Debug.Log(this.Health);
        this.slider.value = Health / 100;
    }
}
