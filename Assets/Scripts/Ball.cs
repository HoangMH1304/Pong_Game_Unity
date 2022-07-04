using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ball : MonoBehaviour
{
    public float moveSpeed = 30;
    public TextMeshProUGUI displayScore1;
    public TextMeshProUGUI displayScore2;
    public TextMeshProUGUI result;
    private Rigidbody2D rigidBody;
    private int score1 = 0;
    private int score2 = 0;
    private bool gameOver = false;
    private AudioSource audioSource;    
    
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = Vector2.right * moveSpeed;
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if((other.gameObject.tag == "Wall")) handleWallTag(other);
        if(other.gameObject.tag == "Player") handlePlayerTag(other);
    }

    void handleWallTag(Collision2D other)
    {
        if(other.gameObject.name == "West Wall" || other.gameObject.name == "East Wall")
            {
                transform.position = Vector2.zero;
                updateScore(other);
            }
        else
        {
            Sound.instance.playOneShot(Sound.instance.wallBloop);
        }
    }

    void handlePlayerTag(Collision2D other)
    {
        reflectBall(other);
        Sound.instance.playOneShot(Sound.instance.hitPaddleBloop);
    }

    void reflectBall(Collision2D other)
    {
        float y = collisionPos(transform.position, other.transform.position, other.collider.bounds.size.y);
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

    float collisionPos(Vector2 ball, Vector2 paddle, float paddleHeight)
    {
        return (ball.y - paddle.y) / paddleHeight;
    }

    void updateScore(Collision2D other)
    {
        if(other.gameObject.name == "West Wall") score2++;
        if(other.gameObject.name == "East Wall") score1++;
        displayScore1.text = score1.ToString();
        displayScore2.text = score2.ToString();
        if(score1 == 5)
        {
            result.text = "You win!";
            gameOver = true;
            Sound.instance.playOneShot(Sound.instance.winSound);
        }
        if(score2 == 5)
        {
            result.text = "Bot win!"; 
            gameOver = true;
            Sound.instance.playOneShot(Sound.instance.lossBuzz);
        }
        if(gameOver) rigidBody.velocity = Vector2.zero;
    }
}
//camelcase
//static
//class vs object
//instance
//dry code  