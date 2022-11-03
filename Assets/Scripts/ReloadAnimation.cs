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

    private bool reloading = false;

    // Start is called before the first frame update
    void Start()
    {
        this.reloadSpriteImage.fillAmount = 0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            this.reloading = true;
        }

        if (reloading)
        {
            indicatorTimer -= Time.deltaTime;
            
            reloadSpriteImage.fillAmount = indicatorTimer;

            if (indicatorTimer >= maxIndicatorTimer)
            {
                this.reloadSpriteImage.fillAmount = 0f;
                reloading = false;
                //this.gameObject.SetActive(false);
            }
        }


    }
}
