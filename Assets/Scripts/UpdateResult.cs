using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateResult : MonoBehaviour
{
    public TextMeshProUGUI displayScore1;
    public TextMeshProUGUI displayScore2;
    public TextMeshProUGUI result;
    private int score1 = 0;
    private int score2 = 0;
    private bool gameOver = false;
    private Rigidbody2D rigidBody;
    private AudioSource audioSource;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    public void UpdateScore(Collision2D other)
    {
        if(other.gameObject.name == "West Wall") score2++;
        if(other.gameObject.name == "East Wall") score1++;
        displayScore1.text = score1.ToString();
        displayScore2.text = score2.ToString();
        if(score1 == 5)
        {
            result.text = "You win!";
            gameOver = true;
            Sound.instance.PlayOneShot(Sound.instance.winSound);
        }
        if(score2 == 5)
        {
            result.text = "Bot win!"; 
            gameOver = true;
            Sound.instance.PlayOneShot(Sound.instance.lossBuzz);
        }
    }

    public bool GetResult()
    {
        return gameOver;
    }
}
