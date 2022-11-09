using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrientationLock : MonoBehaviour
{

    DeviceOrientation lastOrientation;
    Image image;
    Color originalColor;

    private void Start()
    {
        image = GetComponent<Image>();
        originalColor = image.color;
    }

    // Update is called once per frame
    void Update()
    {
        lastOrientation = Input.deviceOrientation;
    }

    public void OnFingerDown()
    {
        int orientation = (int)lastOrientation;

        if (orientation > 4)
            orientation = (int)DeviceOrientation.LandscapeLeft;

        Screen.autorotateToLandscapeLeft = false;
        Screen.autorotateToLandscapeRight = false;
        Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;

        Screen.orientation = (ScreenOrientation) lastOrientation;

        Color newColor = image.color;
        newColor.a = 1f;
        image.color = newColor;
    }

    public void OnFingerUp()
    {
        Screen.autorotateToLandscapeLeft = true;
        Screen.autorotateToLandscapeRight = true;
        Screen.autorotateToPortrait = true;
        Screen.autorotateToPortraitUpsideDown = true;

        Screen.orientation = ScreenOrientation.AutoRotation;

        image.color = originalColor;
    }
}
