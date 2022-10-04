using System;
using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public int id;

    // Start is called before the first frame update
    private void Start()
    {
        GameEvents.current.onDoorwayTriggerEnter += OnDoorwayOpen;
        GameEvents.current.onDoorwayTriggerExit += OnDoorwayClose;
    }

    // Update is called once per frame
    private void OnDoorwayOpen(int id)
    {
        if (id == this.id)
        { 
            LeanTween.moveLocalY(gameObject, 1.9f, 1f).setEaseOutQuad();
        }
        
    }

    private void OnDoorwayClose(int id)
    {
        if (id == this.id)
        {
            LeanTween.moveLocalY(gameObject, .5f, 1f).setEaseOutQuad();
        }
    }

    private void OnDestroy()
    {
        GameEvents.current.onDoorwayTriggerEnter -= OnDoorwayOpen;
        GameEvents.current.onDoorwayTriggerExit -= OnDoorwayClose;
    }
}
