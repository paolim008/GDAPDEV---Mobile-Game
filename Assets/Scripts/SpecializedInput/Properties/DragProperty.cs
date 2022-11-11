using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DragProperty
{
    [Tooltip("How long must the finger be on screen for it to be registered as a drag")]
    public float bufferTime = 0.8f;
}
