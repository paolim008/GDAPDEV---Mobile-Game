using System;
using UnityEngine;

public class SwipeEventArgs : EventArgs
{
    private SwipeDirection swipeDirection;
    public SwipeDirection SwipeDirection
    {
        get { return swipeDirection; }
    }
    private Vector2 swipePos;
    public Vector2 SwipePos
    {
        get { return swipePos; }
    }
    private GameObject hitObj;
    public GameObject HitObject
    {
        get { return hitObj; }
    }
    private Vector2 swipeVector;
    public Vector2 SwipeVector
    {
        get { return swipeVector; }
    }

    public SwipeEventArgs(SwipeDirection direction, Vector2 swipePos, Vector2 swipeVector, GameObject hitObj=null)
    {
        this.swipeDirection = direction;
        this.swipePos = swipePos;
        this.swipeVector = swipeVector;
        this.hitObj = hitObj;
    }
}

public enum SwipeDirection
{
    RIGHT,
    LEFT,
    UP,
    DOWN
}