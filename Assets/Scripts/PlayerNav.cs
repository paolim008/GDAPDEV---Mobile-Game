using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNav : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private GameObject[] destinationPoint;
    [SerializeField] private GameObject[] facePoint;
    //private float ticks = 0;
    public int currentPoint = 0;
    private Vector3 offsetPlayer;
    [SerializeField] private bool moving = false;
    private bool endScreenDisplayed = false;

    // Start is called before the first frame update
    public void Start()
    {
        
        offsetPlayer.Set(0.0f, 0.1f, -1.0f);
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(destinationPoint[currentPoint].transform.position);
        agent.Move(offsetPlayer);
        
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            moving = !moving;
        }

        RotateViewToFocus(agent, facePoint[currentPoint]);
        //Check if agent reached the destination point
        if (agent.remainingDistance <= 0)
        {


            if (currentPoint+1 >= destinationPoint.Length && !endScreenDisplayed)
                {
                    Debug.Log("Stage Complete");
                    //Display Win Screen
                    endScreenDisplayed = true;

                }
            
            //Set new destination to the Agent
            if(currentPoint+1 < destinationPoint.Length)
                WaitForNextArea();


        }

   
    }

    private void RotateViewToFocus(NavMeshAgent agent, GameObject facePoint)
    {
        Quaternion lockOnLook = Quaternion.LookRotation(facePoint.transform.position - agent.transform.position);
        agent.transform.rotation = Quaternion.Slerp(agent.transform.rotation, lockOnLook, 4*Time.deltaTime);

    }

    private void WaitForNextArea()
    {
        if (moving == true)
        {
            currentPoint++;
            agent.SetDestination(destinationPoint[currentPoint].transform.position);
        }
            
    }
}
