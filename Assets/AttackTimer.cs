using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackTimer : MonoBehaviour
{
    [SerializeField] private Slider attackTimerSlider;
    [SerializeField] private Image attackTimerColor;
    
    private float attackCooldown;

    void Awake()
    {

    }

    void Update()
    {
        attackCooldown = GetComponentInParent<EnemyAi>().GetCooldown();
        attackTimerSlider.maxValue = attackCooldown;
        if (attackTimerSlider.value >= attackCooldown)
            attackTimerSlider.value = 0;
        else
        {
            attackTimerSlider.value += Time.deltaTime;
            attackTimerColor.color =
                Color.Lerp(Color.green, Color.red, attackTimerSlider.value / attackCooldown);
        }
        
    }

}
