using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftPaddle : MonoBehaviour
{
    public float moveSpeed;
    void Update()
    {
        movingLeftPaddle();
    }

    void movingLeftPaddle()
    {
        if(Input.GetKey(KeyCode.UpArrow) && transform.position.y < 21)
        {
            transform.position += new Vector3(0, moveSpeed * Time.deltaTime, 0);
        }
        if(Input.GetKey(KeyCode.DownArrow) && transform.position.y > -21)
        {
            transform.position += new Vector3(0, -moveSpeed * Time.deltaTime, 0);
        }
    }
}
