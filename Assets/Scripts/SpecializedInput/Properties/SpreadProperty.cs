using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpreadProperty
{
    [Tooltip("Minimum change in distance between the fingers to register spread/pinch")]
    public float MinDistanceChange = 0.2f;
}
