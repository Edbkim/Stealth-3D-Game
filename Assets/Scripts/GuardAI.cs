using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardAI : MonoBehaviour
{
    public List<Transform> wayPoints;
    private NavMeshAgent _agent;
    private Animator _animator;

    public bool coinTossed;
    
    [SerializeField]
    private int _currentTarget;

    public Vector3 coinPos;

    [SerializeField]
    private bool _reverse;
    [SerializeField]
    private bool _targetReached;


    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();

        _animator = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {

        if (wayPoints.Count > 0 && wayPoints[_currentTarget] != null && coinTossed == false)
        {
            _agent.SetDestination(wayPoints[_currentTarget].position);

            float distance = Vector3.Distance(transform.position, wayPoints[_currentTarget].position);

            if (distance < 1 && (_currentTarget == 0 || _currentTarget == wayPoints.Count - 1))
            {
                if (_animator != null)
                {
                    _animator.SetBool("Walk", false);
                }
                
            }
            else
            {
                if (_animator != null)
                {
                    _animator.SetBool("Walk", true);
                }

            }

            if (distance < 1.5f && _targetReached == false)
            {
                Debug.Log("Distance less than 1.5");
                if (wayPoints.Count <= 1)
                {
                    Debug.Log("No more way points");
                    return;
                }

                if ((_currentTarget == 0 || _currentTarget == wayPoints.Count - 1) && wayPoints.Count > 1)
                {
                    _targetReached = true;

                    Debug.Log("Start Coroutine");

                    StartCoroutine(WaitBeforeMoving());
                }
                else
                {
                    if (_reverse == true)
                    {
                        _currentTarget--;

                        if (_currentTarget <= 0)
                        {
                            _reverse = false;
                            _currentTarget = 0;
                        }
                    }
                    else if (_reverse == false) 
                        {
                            Debug.Log("Next Waypoint");
                            _currentTarget++;
                        }
                }
                    
                
            }
        }
        else
        {
            float distance = Vector3.Distance(transform.position, coinPos);
            if (distance < 5f)
            {
                _animator.SetBool("Walk", false);
            }

        }

    }

    IEnumerator WaitBeforeMoving()
    {
         if (_currentTarget == 0)
        {
            yield return new WaitForSeconds(Random.Range(2f, 5f));
        }
        else if (_currentTarget == wayPoints.Count - 1)
        {

            yield return new WaitForSeconds(Random.Range(2f, 5f));
        }
        else
        {
            yield return null;
        }

        if (_reverse == true)
        {
            _currentTarget--;

            if (_currentTarget == 0)
            {
                _reverse = false;
                _currentTarget = 0;
            }
        }
        else if (_reverse == false)
        {
            _currentTarget++;

            if (_currentTarget == wayPoints.Count)
            {
                _reverse = true;
                _currentTarget--;
            }
        }
        _targetReached = false;
        
    }

  
}
