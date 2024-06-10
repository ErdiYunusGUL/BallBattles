using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    public GameObject canvas;
    bool isPaused = false;

    private void Start()
    {
        canvas.SetActive(false);
    }
    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Q) && !isPaused)
        //{
        //    Pause();
        //}
        //else if (Input.GetKeyDown(KeyCode.Q) && isPaused)
        //{
        //    Resume();
        //}

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }
    private void TogglePause()
    {
        isPaused = !isPaused;

        canvas.SetActive(isPaused); 
        Time.timeScale = isPaused ? 0.0f : 1.0f; 
    }

    public void Resume()
    {
        canvas.SetActive(false);
        Time.timeScale = 1.0f;
        isPaused = false;
    }

    public void Pause()
    {
        canvas.SetActive(true);
        Time.timeScale = 0.0f;
        isPaused = true;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }
    public void OnQuitButton()
    {
        Application.Quit();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
