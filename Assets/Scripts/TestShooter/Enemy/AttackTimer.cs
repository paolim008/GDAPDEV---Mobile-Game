using UnityEngine;
using UnityEngine.UI;
using Time = UnityEngine.Time;


public class AttackTimer : MonoBehaviour
{
    [SerializeField] private Image timerFillImage;
    private float maxTimer;
    private Color timerColor;
    private float currTimer;
    

    void Update()
    {
        maxTimer = GetComponent<EnemyAi>().GetCooldown();

        if (currTimer / maxTimer >= 1)
        {
            currTimer = 0;
            timerFillImage.fillAmount = 0;
        }
        else
        {
            currTimer += Time.deltaTime;
            timerColor = Color.Lerp(Color.yellow, Color.red, currTimer / maxTimer);
            timerFillImage.color = timerColor;
            timerFillImage.fillAmount = currTimer / maxTimer;
        }

    }

}


