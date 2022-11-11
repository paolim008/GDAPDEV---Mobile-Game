using System;
using UnityEngine;

public class DragEventArgs : EventArgs
{
    public Touch TargetFinger
    {
       private set; get;
    }

    public GameObject HitObject
    {
        private set; get;
    }

    public DragEventArgs(Touch targetFinger, GameObject hitObject=null)
    {
        TargetFinger = targetFinger;
        HitObject = hitObject;
    }
}
