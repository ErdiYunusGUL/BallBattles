using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    
  

    // Called when we click the "Play" button.


    public void OnPlayButton()
    {
        SceneManager.LoadScene(1);
    }
    public void OnMainButton()
    {
        SceneManager.LoadScene(0);
    }
    // Called when we click the "Quit" button.
    public void OnQuitButton()
    {
        Application.Quit();
    }

    
}
