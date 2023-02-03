using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftPaddle : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 30f;
    private const int TOP_CORNER = 21;
    private const int BOTTOM_CORNER = -21;

    void Update()
    {
        MovingLeftPaddle();
    }

    void MovingLeftPaddle()
    {
        if(Input.GetKey(KeyCode.UpArrow) && transform.position.y < TOP_CORNER)
        {
            transform.position += new Vector3(0, moveSpeed * Time.deltaTime, 0);
        }
        if(Input.GetKey(KeyCode.DownArrow) && transform.position.y > BOTTOM_CORNER)
        {
            transform.position += new Vector3(0, -moveSpeed * Time.deltaTime, 0);
        }
    }
}
