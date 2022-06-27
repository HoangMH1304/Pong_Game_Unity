using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float moveSpeed = 30;
    private Rigidbody2D rigidBody;
    
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = Vector2.right * moveSpeed;
    }

    void OnCollisionEnter2D(Collision2D col) {
        if((col.gameObject.tag == "Wall"))
        {
            if(col.gameObject.name == "West Wall" || col.gameObject.name == "East Wall")
            {
                transform.position = new Vector2(0, 0);
            }
        }
        if(col.gameObject.tag == "Player")
        {
            handlePaddleHit(col);
        }
        
    }

    void handlePaddleHit(Collision2D col)
    {
        float y = BallHitPaddleWhere(transform.position, col.transform.position, col.collider.bounds.size.y);
        Vector2 dir = new Vector2();
        if(col.gameObject.name == "Left Paddle")
        {
            dir =  new Vector2(1, y).normalized;
        }
        if(col.gameObject.name == "Right Paddle")
        {
            dir = new Vector2(-1, y).normalized;
        }
        rigidBody.velocity = dir * moveSpeed;
    }

    float BallHitPaddleWhere(Vector2 ball, Vector2 paddle, float paddleHeight)
    {
        return (ball.y - paddle.y) / paddleHeight;
    }
}
