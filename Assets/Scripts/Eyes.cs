using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameOver;

    //detect darren when caught in eyes


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _gameOver.SetActive(true);

        }
    }
}
