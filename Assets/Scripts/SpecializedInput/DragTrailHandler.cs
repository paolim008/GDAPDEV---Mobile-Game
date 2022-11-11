using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragTrailHandler : MonoBehaviour
{
    public float trailDistance = 5f;

    // Start is called before the first frame update
    void Start()
    {
        GestureManager.Instance.OnDrag += OnDrag;
    }

    private void OnDisable()
    {
        GestureManager.Instance.OnDrag -= OnDrag;
    }

    private void OnDrag(object sender, DragEventArgs args)
    {
        if (args.HitObject != null)
            return;

        Ray r = Camera.main.ScreenPointToRay(args.TargetFinger.position);

        Vector3 trailPos = r.GetPoint(trailDistance);
        transform.position = trailPos;
    }
}
