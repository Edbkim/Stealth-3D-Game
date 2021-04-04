using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    //variable to hold the object you want to look at
    [SerializeField]
    private Transform _player;
    [SerializeField]
    public Transform startCamera;

    private void Start()
    {
        transform.position = startCamera.position;
        transform.rotation = startCamera.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (_player != null)
        {
            transform.LookAt(_player);
        }

    }
}
