using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ParentScript : MonoBehaviour
{
    private ParentScript psref;
    [HideInInspector] public NavMeshAgent agent;
    [HideInInspector] public PlayerNav PNreference;


    void Awake()
    {
        psref = this;
        agent = GetComponent<NavMeshAgent>();
        PNreference = GetComponentInChildren<PlayerNav>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //PNreference.start(ref psref);
        
    }

    // Update is called once per frame
    void Update()
    {
        //PNreference.update(ref psref);
    }
}
