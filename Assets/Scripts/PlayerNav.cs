using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNav : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private GameObject[] destinationPoint;
    [SerializeField] private GameObject[] facePoint;
    private float ticks = 0;
    public int currentPoint = 0;
    [SerializeField] private float interval = 5;
    private Vector3 offsetPlayer;


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
        //Check if agent reached the destination point
        if (agent.remainingDistance <= 0)
        {
            ticks+= Time.deltaTime;
            //Rotates Agent to look at the direction of facePoint
            RotateViewToFocus(agent, facePoint[currentPoint]);

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
    private void RotateViewToFocus(NavMeshAgent agent, GameObject facePoint)
    {
        Quaternion lockOnLook = Quaternion.LookRotation(facePoint.transform.position - agent.transform.position);
        agent.transform.rotation = Quaternion.Slerp(agent.transform.rotation, lockOnLook, Time.deltaTime);

    }


}

//#region Experimental Class
//public class PlayerNav : MonoBehaviour
//{
//    //private NavMeshAgent agent;
//    [SerializeField] private GameObject[] destinationPoint;
//    [SerializeField] private GameObject[] facePoint;
//    private float ticks = 0;
//    public int currentPoint = 0;
//    [SerializeField] private float interval = 5;
//    private Vector3 offsetPlayer;


//    // Start is called before the first frame update
//    public void start(ref ParentScript parentref)
//    {

//        offsetPlayer.Set(0.0f, 0.1f, -1.0f);
//        parentref.agent = GetComponent<NavMeshAgent>();
//        parentref.agent.SetDestination(destinationPoint[currentPoint].transform.position);
//        parentref.agent.Move(offsetPlayer);

//    }

//    // Update is called once per frame
//    public void update(ref ParentScript parentref)
//    {
//        //Check if agent reached the destination point
//        if (parentref.agent.remainingDistance <= 0)
//        {
//            ticks += Time.deltaTime;
//            //Rotates Agent to look at the direction of facePoint
//            RotateViewToFocus(parentref.agent, facePoint[currentPoint]);

//            //Reset ticks when over interval
//            if (ticks >= interval)
//            {
//                ticks = 0;

//                //Reset currentPoint if out of bounds
//                if (++currentPoint >= destinationPoint.Length)
//                {
//                    currentPoint = 0;
//                }
//                //Set new destination to the Agent
//                parentref.agent.SetDestination(destinationPoint[currentPoint].transform.position);
//            }
//        }



//    }
//    private void RotateViewToFocus(NavMeshAgent agent, GameObject facePoint)
//    {
//        Quaternion lockOnLook = Quaternion.LookRotation(facePoint.transform.position - agent.transform.position);
//        agent.transform.rotation = Quaternion.Slerp(agent.transform.rotation, lockOnLook, Time.deltaTime);

//    }


//}
//#endregion
