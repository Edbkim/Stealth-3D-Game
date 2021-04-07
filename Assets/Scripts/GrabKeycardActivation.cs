using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabKeycardActivation : MonoBehaviour
{
    [SerializeField]
    private GameObject _keycardCutscene;
    private BoxCollider _collider;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _keycardCutscene.SetActive(true);
            _collider = GetComponent<BoxCollider>();
            _collider.enabled = false;

            GameManager.Instance.HasCard = true;
        }
    }

}
