using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightPaddle : MonoBehaviour
{
    private const int TOP_CORNER = 21;
    private const int BOTTOM_CORNER = -21;
    private const int MIDDLE_PART = 0;
    public float moveSpeed;
    public Rigidbody2D ball;

    void Update()
    {
        MovingRightPaddle();
    }

    void MovingRightPaddle()
    {
        ResetPosition();
        if (transform.position.y < ball.position.y && transform.position.y < TOP_CORNER && isBotSide(ball.position))
        {
            transform.position += new Vector3(0, moveSpeed * Time.deltaTime, 0);
        }
        if (transform.position.y > ball.position.y && transform.position.y > BOTTOM_CORNER && isBotSide(ball.position))
        {
            transform.position += new Vector3(0, -moveSpeed * Time.deltaTime, 0);
        }
    }

    bool isBotSide(Vector3 ball)
    {
        return ball.x > MIDDLE_PART;        
    }
    
    private void ResetPosition()
    {
        if (ball.position.Equals(Vector3.zero))
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
    }
}
