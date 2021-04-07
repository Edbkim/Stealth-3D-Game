using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;

    public static UIManager instance
    {
        get
        {
            if (_instance == null)
            {

                Debug.LogError("UIManager == null");

            }

            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    public void Restart()
    {
        SceneManager.LoadScene("Main");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
