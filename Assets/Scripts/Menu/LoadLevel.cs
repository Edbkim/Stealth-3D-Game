using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour
{

    //reference to the progress bar
    [SerializeField]
    private Image progBar;

    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(LoadLevelAsync());
    }


    IEnumerator LoadLevelAsync()
    {
 

        AsyncOperation async = SceneManager.LoadSceneAsync("Main");

        while (async.isDone == false)
        {
            progBar.fillAmount = async.progress;

            yield return new WaitForEndOfFrame();
        }
    }
}
