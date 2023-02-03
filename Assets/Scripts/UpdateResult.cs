using UnityEngine;
using TMPro;

public class UpdateResult : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI displayScore1;
    [SerializeField]
    private TextMeshProUGUI displayScore2;
    [SerializeField]
    private TextMeshProUGUI result;
    [SerializeField]
    private TextMeshProUGUI notify;
    
    private int score1 = 0;
    private int score2 = 0;
    private bool gameOver = false;
    private AudioSource audioSource;

    public void AdjustScore(Collision2D other)
    {
        if (other.gameObject.name == "West Wall") score2++;
        if (other.gameObject.name == "East Wall") score1++;
        UpdateScoreUI();
        if (score1 == 5)
        {
            result.text = "You win!";
            UpdateGameState();
            Sound.instance.PlayOneShot(Sound.instance.winSound);
        }
        if (score2 == 5)
        {
            result.text = "Bot win!";
            UpdateGameState();
            Sound.instance.PlayOneShot(Sound.instance.lossBuzz);
        }
    }

    private void UpdateGameState()
    {
        gameOver = !gameOver;
        notify.enabled = !notify.enabled;
    }

    private void UpdateScoreUI()
    {
        displayScore1.text = score1.ToString();
        displayScore2.text = score2.ToString();
        result.text = "";
    }

    public bool GetResult()
    {
        return gameOver;
    }

    public void Reset()
    {
        score1 = 0;
        score2 = 0;
        UpdateGameState();
        UpdateScoreUI();
    }
}
