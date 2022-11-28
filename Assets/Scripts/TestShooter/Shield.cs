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
    private float maxShields;
    private bool onCooldown;


    // Start is called before the first frame update
    void Start()
    {
        currentShields = startingShields;
        maxShields = currentShields;
        shieldSlider.maxValue = maxShields;
        shieldSlider.value = currentShields;
    }

    void Update()
    {
        if(!onCooldown && currentShields != maxShields)
            StartCoroutine(ReplenishShields());
        if (Input.GetKeyDown(KeyCode.M))
        {
            currentShields--;
            shieldSlider.value = currentShields;
        }
    }

    IEnumerator ReplenishShields()
    {
        Debug.Log("Replenishing Shields");
        onCooldown = true;
        yield return new WaitForSeconds(3f);
        if(currentShields + 1 <= maxShields)
            currentShields++;
        shieldSlider.value = currentShields;
        onCooldown = false;
    }


    public void TakeShieldDamage(float _damage)
    {
        currentShields -= _damage;
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
}
