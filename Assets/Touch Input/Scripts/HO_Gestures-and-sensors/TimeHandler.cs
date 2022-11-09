using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeHandler : MonoBehaviour
{
    // Instead of using serialize field, a cleaner approach would be to use event broadcasters.
    // GameManager would not then be tied to game objects in a scene, which would then allow its usage on other scenes.
    [SerializeField] private TextMeshProUGUI timeValue;
    public float changeFactor = 0.005f;
    private float currentTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        GestureManager.Instance.OnRotate += OnRotate;
    }

    private void OnDisable()
    {
        GestureManager.Instance.OnRotate -= OnRotate;
    }

    void OnRotate(object sender, RotateEventArgs args)
    {
        float change = args.Angle * changeFactor;
        if (args.RotationDirection == RotateDirection.CCW)
            change *= -1;
        currentTime += change;
        currentTime = Mathf.Clamp(currentTime, 0, 1);
        Time.timeScale = currentTime;
        timeValue.SetText($"Time Scale: {currentTime}");
    }
}
