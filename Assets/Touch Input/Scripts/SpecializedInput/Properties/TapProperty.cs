using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TapProperty
{
    [Tooltip("Maximum allowable time until its not a tap anymore")]
    public float tapTime = 0.7f;
    [Tooltip("Maximum allowable distance until its not a tap anymore")]
    public float tapMaxDistance = 0.5f;
}
