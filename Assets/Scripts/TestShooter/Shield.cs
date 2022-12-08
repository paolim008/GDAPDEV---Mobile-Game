using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shield : MonoBehaviour
{

    [SerializeField] private float startingShields;
    [SerializeField] private float currentShields;
    [SerializeField] private Slider shieldSlider;
    [SerializeField] private const float shieldCooldown = 5f;
    private float maxShields;
    private bool onCooldown;


    // Start is called before the first frame update
    void Start()
    {
        currentShields = maxShields;
        shieldSlider.maxValue = maxShields;
        shieldSlider.value = currentShields;
    }

    void Update()
    {
        
        if (!onCooldown && currentShields != maxShields)
            StartCoroutine(ReplenishShields());
        if (Input.GetKeyDown(KeyCode.M))
        {
            currentShields--;
            shieldSlider.value = currentShields;
        }
    }

    IEnumerator ReplenishShields()
    {
        
        onCooldown = true;
        yield return new WaitForSeconds(shieldCooldown);
            if (currentShields + 1 <= maxShields && !GestureManager.Instance.IsBlocking())
            {
                Debug.Log("Replenishing Shields");
                currentShields++;
            }
        shieldSlider.value = currentShields;
        onCooldown = false;
    }


    public void TakeShieldDamage(float _damage)
    {
        currentShields -= _damage;
        if(currentShields > 0)
            AudioManager.instance.Play("Shield_Hit");
        else
            AudioManager.instance.Play("Shield_Broken");
        shieldSlider.value = currentShields;
    }

    public float GetCurrentShields()
    {
        return currentShields;
    }
    public float GetMaxShields()
    {
        return maxShields;
    }

    public void SetMaxShield(float _maxShield)
    {
        maxShields = _maxShield;
        currentShields = maxShields;
    }
}
