using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanCameraController : MonoBehaviour
{
    public float speed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        GestureManager.Instance.OnTwoFingerPan += OnTwoFingerPan;
    }

    private void OnDisable()
    {
        GestureManager.Instance.OnTwoFingerPan -= OnTwoFingerPan;
    }

    void OnTwoFingerPan(object sender, TwoFingerPanEventArgs args)
    {
        Vector2 delta1 = args.Finger1.deltaPosition;
        Vector2 delta2 = args.Finger2.deltaPosition;

        Vector2 ave = new Vector2((delta1.x + delta2.x) / 2, (delta1.y + delta2.y) / 2);

        ave = ave / Screen.dpi;

        transform.position += (Vector3) ave * speed;
    }
}
