using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightPaddle : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D ball;

    void Update()
    {
        MovingRightPaddle();
    }

    void MovingRightPaddle()
    {
        if(ball.position.Equals(Vector3.zero))
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
        if(transform.position.y < ball.position.y && transform.position.y < 21 && ball.position.x > 0)
        {
            transform.position += new Vector3(0, moveSpeed * Time.deltaTime, 0);
        }
        if(transform.position.y > ball.position.y && transform.position.y > -21 && ball.position.x > 0)
        {
            transform.position += new Vector3(0, -moveSpeed * Time.deltaTime, 0);
        }
    }
}
