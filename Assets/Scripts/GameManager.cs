using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;

    private int timeLeft;
    private int score;
    public bool isGameActive;

    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
        score = 0;
        timeLeft = 60;
        UpdateScore(0);
        StartCoroutine(CountDown());
    }

    IEnumerator CountDown()
    {
        while (isGameActive)
        {
            timeText.text = "Time left: " + timeLeft;
            yield return new WaitForSeconds(1);
            timeLeft--;

            if (timeLeft < 0)
            {
                GameOver();
            }
        }
    }

    // Update score with value
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    // Stop game, bring up game over text and restart button
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
