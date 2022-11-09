using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameMenu : MonoBehaviour
{

    [SerializeField] GameObject optionsPanel;
    [SerializeField] Animator optionsAnimator;
    [SerializeField] bool isOptionsPanelShown = false;
    [SerializeField] TextMeshProUGUI healthTxt;
    [SerializeField] TextMeshProUGUI ammoTxt;
    [SerializeField] Slider rSlider;
    [SerializeField] Slider gSlider;
    [SerializeField] Slider bSlider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTitlePressed()
    {
        SceneManager.LoadScene(0);
    }

    public void OnOptionsPressed()
    {
        if (!isOptionsPanelShown)
            optionsPanel.SetActive(true);

        isOptionsPanelShown = !isOptionsPanelShown;
        optionsAnimator.SetBool("isOptionsVisible", isOptionsPanelShown);
    }

    public void OnColorSliderChanged()
    {
        Color c = new Color(rSlider.value, gSlider.value, bSlider.value);

        healthTxt.color = c;
        ammoTxt.color = c;
    }

}
