using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManifestExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            Handheld.Vibrate();
        }

        Input.location.Start();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Test");
    }
}
