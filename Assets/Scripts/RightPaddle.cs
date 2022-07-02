using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightPaddle : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D ball;

    float xDirection;

    void FixedUpdate()
    {
        xDirection = ball.position.y;
        if(xDirection < transform.position.y) xDirection = -1;
        else if(xDirection > transform.position.y) xDirection = 1;
        else xDirection = 0;
        float movePosition = moveSpeed * Time.deltaTime * xDirection;
        if(movePosition > ball.transform.position.y) movePosition = ball.position.y;
        // movePosition = ball.position.y - transform.position.y;
        transform.position = new Vector3(transform.position.x, movePosition, transform.position.z);
        //not completed
    }
}
