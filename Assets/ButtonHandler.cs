using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    public void ButtonClick()
    {
        AudioManager.instance.Play("Button_Click");
    }
}
