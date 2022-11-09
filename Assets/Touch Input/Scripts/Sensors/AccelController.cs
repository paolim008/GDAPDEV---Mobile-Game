using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelController : MonoBehaviour
{

    public float speed = 3f;
    public float minChange = 0.2f;

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
        // Rotation
        Quaternion rot = GyroToUnity(Input.gyro.attitude);
        transform.rotation = rot;

        //float x = Input.acceleration.x;
        //if (Mathf.Abs(x) >= minChange)
        //{
        //    x *= speed * Time.deltaTime;
        //    transform.Translate(x, 0, 0);
        //}
    }

    public static Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }

    private void OnDrawGizmos()
    {
        if (Application.isPlaying)
            Debug.DrawRay(transform.position, Input.acceleration.normalized, Color.red);
    }
}
