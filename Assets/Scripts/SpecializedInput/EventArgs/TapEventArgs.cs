using System;
using UnityEngine;

public class TapEventArgs : EventArgs 
{ 
    private Vector2 _tapPosition;
    public Vector2 TapPosition
    {
        get { return _tapPosition; }
    }

    private GameObject _hitObj;
    public GameObject HitObject
    {
        get { return _hitObj; }
    }

    public TapEventArgs(Vector2 tapPosition, GameObject hitObj = null)
    {
        this._tapPosition = tapPosition;
        this._hitObj = hitObj;
    }
}
