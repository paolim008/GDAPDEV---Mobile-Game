using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTest : MonoBehaviour
{

    private int clickCount = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            clickCount++;

        switch (clickCount)
        {
            case 1:
                iTween.MoveTo(this.gameObject, new Vector3(819, 131, 90), 5);
                break;

            case 2:
                iTween.MoveTo(this.gameObject, new Vector3(822, 130, 113), 5);
                break;

            case 3:
                iTween.MoveTo(this.gameObject, new Vector3(826, 127, 125), 5);
                break;

            case 4:
                iTween.MoveTo(this.gameObject, new Vector3(832, 125, 135), 5);
                break;

            case 5:
                iTween.MoveTo(this.gameObject, new Vector3(834, 117, 156), 5);
                break;
        }
    }
}
