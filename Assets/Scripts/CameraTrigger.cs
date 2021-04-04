﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    [SerializeField]
    private Transform _camera;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Trigger Entered");
            Camera.main.transform.position = _camera.position;
            Camera.main.transform.rotation = _camera.rotation; 
        }
    }
}
