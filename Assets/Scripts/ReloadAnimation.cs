using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ReloadAnimation : MonoBehaviour
{
    [SerializeField] private float indicatorTimer;
    [SerializeField] private float maxIndicatorTimer;
    [SerializeField] private Image reloadSpriteImage;
    [SerializeField] private Player playerData;
    [SerializeField] private GameObject[] weapon;
    private int currentWeapon;

    private bool reloading = false;

    // Start is called before the first frame update
    void Start()
    {
        this.reloadSpriteImage.fillAmount = 0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCurrentWeapon();

        if (Input.GetKeyDown(KeyCode.R))
        {
            this.reloading = true;
        }

        if (reloading)
        {
            indicatorTimer += Time.deltaTime;
            
            reloadSpriteImage.fillAmount = indicatorTimer/maxIndicatorTimer;

            if (indicatorTimer >= maxIndicatorTimer)
            {
                
                reloading = false;
                //this.gameObject.SetActive(false);
            }
        }
        else
        {
           indicatorTimer = 0f;
           reloadSpriteImage.fillAmount = indicatorTimer;
        }


    }

    private void UpdateCurrentWeapon()
    {
        currentWeapon = playerData.weaponType;
        maxIndicatorTimer = weapon[currentWeapon].GetComponent<ProjectileGun>().GetReloadTime();
    }

}
