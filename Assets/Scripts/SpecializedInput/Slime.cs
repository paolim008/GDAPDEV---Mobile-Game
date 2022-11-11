using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour, ITappable, ISwipeable, IDraggable, ISpreadable, IRotateable
{
    public float speed = 10f;
    public float sizeSpeed = 1f;
    public float rotateSpeed = 1f;
    private Vector3 targetPos = Vector3.zero;

    private void OnEnable()
    {
        targetPos = transform.position;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }

    public void OnTap()
    {
        Destroy(gameObject);
    }

    public void OnSwipe(SwipeEventArgs e)
    {
        Vector3 dir = Vector3.Normalize(e.SwipeVector);

        targetPos += dir * 5;
    }

    public void OnDrag(DragEventArgs e)
    {
        if (e.HitObject != gameObject)
            return;

        Ray r = Camera.main.ScreenPointToRay(e.TargetFinger.position);

        float distanceToCamera = Vector3.Distance(transform.position, Camera.main.transform.position);
        Vector3 newPoint = r.GetPoint(5);
        targetPos = newPoint;
        transform.position = newPoint;
    }

    public void OnSpread(SpreadEventArgs e)
    {
        if (e.HitObject != gameObject)
            return;

        Debug.Log("Slime hit");
        float scale = (e.DistanceDelta / Screen.dpi) * sizeSpeed;
        Vector3 scaleVector = new Vector3(scale, scale, scale);
        transform.localScale += scaleVector;
    }

    public void OnRotate(RotateEventArgs e)
    {
        if (e.HitObject != gameObject)
            return;

        float angle = e.Angle * rotateSpeed;

        if (e.RotationDirection == RotateDirection.CW)
            angle *= -1;

        transform.Rotate(0, 0, angle);
    }
}
