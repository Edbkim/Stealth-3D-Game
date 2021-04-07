using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SecurityCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameOver;

    [SerializeField]
    private Animator _animator;

    private MeshRenderer _meshRenderer;


    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Color color = new Color(0.6f, 0.1f, 0.1f, 0.3f);
            _meshRenderer.material.SetColor("_TintColor", color);
            StartCoroutine(AlertRoutine());

        }
    }

    IEnumerator AlertRoutine()
    {
        yield return new WaitForSeconds(.5f);
        _gameOver.SetActive(true);
    }


}
