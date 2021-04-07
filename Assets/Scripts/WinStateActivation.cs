using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinStateActivation : MonoBehaviour
{
    [SerializeField]
    private GameObject _win;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (GameManager.Instance.HasCard == true)
            {
                _win.SetActive(true);

                AudioManager.Instance.StopMusic();
                AudioManager.Instance.PlayWin();
                
                

            }
        }
        else
        {
            Debug.Log("You must grab the keycard!");
        }
    }
}
