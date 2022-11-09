using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeDetector : MonoBehaviour
{
    public float distanceThreshold = 1f;
    private Vector3 prevAccel = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        if (prevAccel == Vector3.zero)
        {
            prevAccel = Input.acceleration;
            return;
        }

        Debug.Log($"Accelerometer: {Input.acceleration}");
        float distance = Vector3.Distance(prevAccel, Input.acceleration);
        Debug.Log($"distance: {distance}");

        if (Mathf.Abs(distance) >= distanceThreshold)
        {
            Debug.Log("Shake successful");
            GameManager.Instance.ResetAll();
        }

        prevAccel = Input.acceleration;
    }
}
