using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{

    private Vector3 _target;

    private bool _coinTossed;
    
    [SerializeField]
    private GameObject _coin;

    [SerializeField]
    private AudioClip _coinSFX;

    private NavMeshAgent _agent;
    private Animator _animator;


    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if left click
        //cast a ray from mouse position
        //debug the floor position hit.
        //ray rayorigin
        //ray hit
        //create object at floor position

        if (Input.GetMouseButtonDown(0))
        {
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            

            if (Physics.Raycast(rayOrigin, out hitInfo, 100))
            {
                Debug.Log("Location " + hitInfo.point);
                _agent.SetDestination(hitInfo.point);
                _target = hitInfo.point;
                _animator.SetBool("Walk", true);
            }


        }

        //distance = between player destination 
        //if distance is < 1 from destination
        //stop animation
        float _distance = Vector3.Distance(transform.position, _target);

        if (_distance < 2.0f)
        {
            _animator.SetBool("Walk", false);
        }
        // if player == destination, set bool false

        //if right click
        //instantiate coin at clickedp osition
        //play sound effect for coin drop

        if (Input.GetMouseButtonDown(1) && _coinTossed == false)
        {

            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(rayOrigin, out hitInfo, 100))
            {
                _animator.SetTrigger("Throw");
                _coinTossed = true;
                Instantiate(_coin, hitInfo.point, Quaternion.identity);
                AudioSource.PlayClipAtPoint(_coinSFX, Camera.main.transform.position);
                SendAIToCoinSpot(hitInfo.point);

            }

        }

    }

    void SendAIToCoinSpot(Vector3 coinPos)
    {
        //round up the guards
        //go thorugh each guard
        //navmeshagent.setdestination = coinPos
        GameObject[] guards = GameObject.FindGameObjectsWithTag("Guard1");
        
        foreach (var guard in guards)
        {
            NavMeshAgent currentGuard = guard.GetComponent<NavMeshAgent>();
            GuardAI guardAI = guard.GetComponent<GuardAI>();
            Animator currentAnim = guard.GetComponent<Animator>();

            guardAI.coinTossed = true;
            currentGuard.SetDestination(coinPos);
            currentAnim.SetBool("Walk", true);
            guardAI.coinPos = coinPos;
            
        }

    }

}
