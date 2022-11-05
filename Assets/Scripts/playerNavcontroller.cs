using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerNavcontroller : MonoBehaviour
{
    //private enum PeekDirection
    //{
    //    Up,
    //    UpRight,
    //    UpLeft,
    //    Right,
    //    Left
    //};

    [SerializeField] int npeekdirection;
    [SerializeField] GameObject[] peekPoints;
    [SerializeField] GameObject initPoint;
    public bool Peek;
    private Quaternion initCamRot;
    private Vector3 initCamHeight;
    [SerializeField] private float speedMultiplier;
    // Update is called once per frame

    void Start()
    {
    }
    void Update()
    {
        initCamRot = Camera.main.transform.rotation;
        
        //float x = Input.GetAxis("Horizontal");
        //float z = Input.GetAxis("Vertical");

        //Vector3 move = new Vector3(x*speedMultiplier, 0, z*speedMultiplier);

        //controller.Move(move);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Peek = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            Peek = false;
        }



        if (this.gameObject.GetComponent<PlayerNav>().currentPoint == 2)
        {
            Debug.Log("AAAAASHIT");
        }

        if (Peek) //Peek
        {
            //controller.Move(new Vector3(0, -10*Time.deltaTime, 0));
            Camera.main.transform.SetPositionAndRotation(peekPoints[npeekdirection].transform.position, initCamRot);
            //LeanTween.moveLocalY(gameObject, 1.5f, 0.5f);

        }

        if (!Peek) //Hide
        {
            //controller.Move(new Vector3(0, 10*Time.deltaTime, 0));
            Camera.main.transform.SetPositionAndRotation(initPoint.transform.position, initCamRot);
            //LeanTween.moveLocalY(gameObject, 0.5f, 0.5f).setEaseOutQuad();
        }

        //Debug.Log(Peek);

    }
}
