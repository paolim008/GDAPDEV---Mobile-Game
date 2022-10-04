using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Test : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private GameObject[] destinationPoint;
    private float ticks = 0;
    private int currentPoint = 0;
    [SerializeField] private float interval = 5;
    private Vector3 offsetPlayer;


    // Start is called before the first frame update
    void Start()
    {
        
        offsetPlayer.Set(0.0f, 0.1f, -1.0f);
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(destinationPoint[currentPoint].transform.position);
        agent.Move(offsetPlayer);
    }

    // Update is called once per frame
    void Update()
    {
        //Check if agent reached the destination point
        if (agent.remainingDistance <= 0)
        {
            ticks+= Time.deltaTime;

            //Reset ticks when over interval
            if (ticks >= interval)
            {
                ticks = 0;

                //Reset currentPoint if out of bounds
                if (++currentPoint >= destinationPoint.Length)
                {
                    currentPoint = 0;
                }
                //Set new destination to the Agent
                agent.SetDestination(destinationPoint[currentPoint].transform.position);
            }
        }
       
       

    }
}
