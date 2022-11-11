using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSFX : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Press()
    {
        GameObject.FindGameObjectWithTag("SFX").GetComponent<SFXManager>().PressButton();
    }
}
