using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playercontroller : MonoBehaviour
{
    public CharacterController controller;

    [SerializeField] private float speedMultiplier;
    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(x*speedMultiplier, 0, z*speedMultiplier);

        controller.Move(move);
    }
}
