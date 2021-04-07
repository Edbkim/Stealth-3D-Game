using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

// start -- game
//quit -- quit application

    public void StartGame()
    {
        SceneManager.LoadScene("Loading_Screen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
