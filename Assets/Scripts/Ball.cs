using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ball : MonoBehaviour
{
    public float moveSpeed = 30;
    public GameObject otherGameobject;
    private Rigidbody2D rigidBody;
    private UpdateResult updateResult;
    private AudioSource audioSource;    
    
    void Start()
    {
        updateResult = otherGameobject.GetComponent<UpdateResult>();

        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = Vector2.left * moveSpeed;
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if((other.gameObject.tag == "Wall")) HandleWallTag(other);
        if(other.gameObject.tag == "Player") HandlePlayerTag(other);
    }

    void HandleWallTag(Collision2D other)
    {
        if(other.gameObject.name == "West Wall" || other.gameObject.name == "East Wall")
            {
                updateResult.UpdateScore(other);
                transform.position = Vector2.zero;
                if(updateResult.GetResult()) rigidBody.velocity = Vector2.zero;
            }
        else
        {
            Sound.instance.PlayOneShot(Sound.instance.wallBloop);
        }
    }

    void HandlePlayerTag(Collision2D other)
    {
        ReflectBall(other);
        Sound.instance.PlayOneShot(Sound.instance.hitPaddleBloop);
    }

    void ReflectBall(Collision2D other)
    {
        float y = GetCollisionPos(transform.position, other.transform.position, other.collider.bounds.size.y);
        Vector2 dir = new Vector2();
        if(other.gameObject.name == "Left Paddle")
        {
            dir = new Vector2(1, y).normalized;
        }
        if(other.gameObject.name == "Right Paddle")
        {
            dir = new Vector2(-1, y).normalized;
        }
        rigidBody.velocity = dir * moveSpeed;
    }

    float GetCollisionPos(Vector2 ball, Vector2 paddle, float paddleHeight)
    {
        return (ball.y - paddle.y) / paddleHeight;
    }
}
//camelcase
//static
//class vs object
//instance
//dry code  