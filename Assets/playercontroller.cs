using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playercontroller : MonoBehaviour
{

    public bool Peek;

    public CharacterController controller;

    [SerializeField] private float speedMultiplier;
    // Update is called once per frame
    void Update()
    {
        //float x = Input.GetAxis("Horizontal");
        //float z = Input.GetAxis("Vertical");

        //Vector3 move = new Vector3(x*speedMultiplier, 0, z*speedMultiplier);

        //controller.Move(move);

        if (Input.GetKey(KeyCode.Space))
        {
            Peek = true;
        }
        else 
        {
            Peek = false;
        }



        if (this.gameObject.GetComponent<Test>().currentPoint == 2)
        {
            Debug.Log("AAAAASHIT");
        }

        if (Peek) //Peek
        {
            //controller.Move(new Vector3(0, -10*Time.deltaTime, 0));
            LeanTween.moveLocalY(gameObject, 1.5f, 0.5f);
        }

        if (!Peek) //Hide
        {
            //controller.Move(new Vector3(0, 10*Time.deltaTime, 0));
            LeanTween.moveLocalY(gameObject, 0.5f, 0.5f).setEaseOutQuad();
        }

        //Debug.Log(Peek);

    }
}
