using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNav : MonoBehaviour
{
    public int currentPoint = 0;

    [SerializeField] private LevelAreaManager levelAreaManager;
    [SerializeField] private GameObject[] destinationPoint;
    [SerializeField] private GameObject[] facePoint;
    [SerializeField] private Transform[] enemyHolders;
    private NavMeshAgent agent;
    private Vector3 offsetPlayer;
    [SerializeField] private bool moving = false;


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
            levelAreaManager.OpenLoadingPanel(false);

            if (currentPoint+1 == enemyHolders.Length && enemyHolders[levelAreaManager.GetLevelStage() - 1].childCount == 0)
            {

                levelAreaManager.OpenPanel(3);
            }

            //Set new destination to the Agent
            if(currentPoint+1 < destinationPoint.Length)
                WaitForNextArea();


        }
        else levelAreaManager.OpenLoadingPanel(true);




    }

    private void RotateViewToFocus(NavMeshAgent agent, GameObject facePoint)
    {
        Quaternion lockOnLook = Quaternion.LookRotation(facePoint.transform.position - agent.transform.position);
        agent.transform.rotation = Quaternion.Slerp(agent.transform.rotation, lockOnLook, 4*Time.deltaTime);

    }

    private void WaitForNextArea()
    {
        if (enemyHolders[levelAreaManager.GetLevelStage()-1].childCount == 0)
        {
            levelAreaManager.OpenLoadingPanel(true);
            currentPoint++;
            agent.SetDestination(destinationPoint[currentPoint].transform.position);
            levelAreaManager.LoadLevelStage();
        }
    }
}
