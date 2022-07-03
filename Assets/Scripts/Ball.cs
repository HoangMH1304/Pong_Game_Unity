using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ball : MonoBehaviour
{
    public float moveSpeed = 30;
    public TextMeshProUGUI Score1;
    public TextMeshProUGUI Score2;
    public TextMeshProUGUI Result;
    private Rigidbody2D rigidBody;
    private int score1 = 0;
    private int score2 = 0;
    private bool Gameover = false;
    
    void Start()
    {
        // Sound.Instance.playOneShot(Sound.Instance.techno_bg_music);
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = Vector2.right * moveSpeed;
    }

    void OnCollisionEnter2D(Collision2D col) 
    {
        if((col.gameObject.tag == "Wall"))
        {
            if(col.gameObject.name == "West Wall" || col.gameObject.name == "East Wall")
            {
                transform.position = Vector2.zero;
                if(col.gameObject.name == "West Wall") score2++;
                else score1++;
                UpdateScore();
                if(Gameover)
                {
                    if(score1 > score2) Sound.Instance.playOneShot(Sound.Instance.WinSound);
                    else Sound.Instance.playOneShot(Sound.Instance.LossBuzz);
                    rigidBody.velocity = Vector2.zero;
                }
            }
            else
            {
                Sound.Instance.playOneShot(Sound.Instance.WallBloop);
            }
        }

        if(col.gameObject.tag == "Player")
        {
            handlePaddleHit(col);
            Sound.Instance.playOneShot(Sound.Instance.HitPaddleBloop);
        }
    }

    void handlePaddleHit(Collision2D col)
    {
        float y = BallHitPaddleWhere(transform.position, col.transform.position, col.collider.bounds.size.y);
        Vector2 dir = new Vector2();
        if(col.gameObject.name == "Left Paddle")
        {
            dir = new Vector2(1, y).normalized;
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

    void UpdateScore()
    {
        Score1.text = score1.ToString();
        Score2.text = score2.ToString();
        if(score1 == 5)
        {
            Result.text = "You win!";
            Gameover = true;
        }
        if(score2 == 5)
        {
            Result.text = "Bot win!"; 
            Gameover = true;
        }
    }
}
