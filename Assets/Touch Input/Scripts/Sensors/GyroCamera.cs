using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (SystemInfo.supportsGyroscope)
        {
            Input.gyro.enabled = true;
        }
        else
        {
            Debug.LogError("Gyroscope not supported in the device.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (Input.gyro.enabled)
        {
            Vector3 rotation = Input.gyro.rotationRate;

            // Invert x and y
            rotation.x *= -1;
            rotation.y *= -1;

            transform.Rotate(rotation);
        }
    }
}
