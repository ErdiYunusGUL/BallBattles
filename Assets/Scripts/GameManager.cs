using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI finishScoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    int score;

    // Start is called before the first frame update
    void Start()
    {

        scoreText.gameObject.SetActive(true); 
        score = 0;
        Time.timeScale = 1.0f;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(false);   
        finishScoreText.gameObject.SetActive(true);
        finishScoreText.text = scoreText.text;
        Time.timeScale = 0.0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (other.GetComponent<EnemyType>().enemyType == EnemyType.EnemyT.Mini)
            {
                score += 5;
                scoreText.text = "Score: " + score;
            }
            else if (other.GetComponent<EnemyType>().enemyType == EnemyType.EnemyT.MiniFast)
            {
                score += 7;
                scoreText.text = "Score: " + score;
            }
            else if (other.GetComponent<EnemyType>().enemyType == EnemyType.EnemyT.Normal)
            {
                score += 10;
                scoreText.text = "Score: " + score;
            }
            else if (other.GetComponent<EnemyType>().enemyType == EnemyType.EnemyT.Fast)
            {
                score += 15;
                scoreText.text = "Score: " + score;
            }
            else if (other.GetComponent<EnemyType>().enemyType == EnemyType.EnemyT.Boss)
            {
                score += 25;
                scoreText.text = "Score: " + score;
            }
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1.0f;
    }
}
