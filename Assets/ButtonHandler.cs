using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    private Image buttonImage;
    [SerializeField] private Sprite[] toggleImages;

    public bool isActive = false;
    private void Awake()
    {
        buttonImage = GetComponent<Image>();
    }

    public void ButtonToggle()
    {
        if (isActive)
        {
            buttonImage.sprite = toggleImages[1];
            //SoundManager.instance.ResumeMusic();
            isActive = !isActive;
        }
        else
        {
            buttonImage.sprite = toggleImages[0];
            //SoundManager.instance.PauseMusic();
            isActive = !isActive;
        }
    }

    public void ButtonClick()
    {
        SoundManager.instance.PlaySFX("Button_Clicked");
    }



}
