using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleTapReceiver : MonoBehaviour
{
    public GameObject toSpawn;

    // Start is called before the first frame update
    void Start()
    {
        GestureManager.Instance.OnTap += OnTap;
        GestureManager.Instance.OnSwipe += OnSwipe;
    }

    private void OnDisable()
    {
        GestureManager.Instance.OnTap -= OnTap;
        GestureManager.Instance.OnSwipe -= OnSwipe;
    }

    private void OnTap(object sender, TapEventArgs args)
    {
        if (args.HitObject == null)
        {
            Ray r = Camera.main.ScreenPointToRay(args.TapPosition);
            Spawn(r.GetPoint(3));
        }
    }
    
    private void OnSwipe(object sender, SwipeEventArgs args)
    {
        Debug.Log("Swipe Received: " + args.SwipeDirection);
    }

    private void Spawn(Vector3 pos)
    {
        Debug.Log("Spawned slime");
        Instantiate(toSpawn, pos, Quaternion.identity);
    }
}
