using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 30;
    private Rigidbody2D rigidBody;
    private UpdateResult updateResult;
    private AudioSource audioSource; 
    const string WEST_WALL = "West Wall";
    const string EAST_WALL = "East Wall";
    const string NORTH_WALL = "North Wall";
    const string SOUTH_WALL = "South Wall";
       
    
    void Start()
    {
        updateResult = GameObject.Find("GameManager").GetComponent<UpdateResult>();
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
        if(other.gameObject.name.Equals(WEST_WALL) || other.gameObject.name.Equals(EAST_WALL))
            {
                updateResult.AdjustScore(other);
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

    private void Update() {
        if(!updateResult.GetResult()) return;
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rigidBody.velocity = Vector2.left * moveSpeed;
            updateResult.Reset();
        }
    }
}