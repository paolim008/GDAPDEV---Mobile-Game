using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadEventArgs : EventArgs
{
    public Touch Finger1 { get; private set; }
    public Touch Finger2 { get; private set; }

    public float DistanceDelta { get; private set; } = 0;

    public GameObject HitObject { get; private set; } = null;

    public SpreadEventArgs (Touch finger1, Touch finger2, float distanceDelta, GameObject hitObject)
    {
        Finger1 = finger1;
        Finger2 = finger2;
        DistanceDelta = distanceDelta;
        HitObject = hitObject;
    }

}
