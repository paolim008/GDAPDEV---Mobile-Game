using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceHandler : MonoBehaviour
{
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
        Ray r = Camera.main.ScreenPointToRay(args.TargetFinger.position);
        transform.position = r.GetPoint(2f);

        // Check whether a sliceable object has been hit
        RaycastHit hit;
        if (Physics.Raycast(r, out hit, Mathf.Infinity))
        {
            SliceableObject slice = hit.collider.gameObject.GetComponent<SliceableObject>();
            if (slice != null)
            {
                slice.OnSliced();
            }
        }
    }
}
