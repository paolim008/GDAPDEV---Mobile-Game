using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            player.health -= 5;
            player.score -= 10;
            Debug.Log("-5");
        }        
        if (Input.GetKeyDown(KeyCode.D))
        {
            player.health += 5;
            player.score += 10;
            Debug.Log("+5");
        }
        
    }
}
