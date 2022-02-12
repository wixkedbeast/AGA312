using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WanderAI : GameBehaviour
{
    public AnimalType animalType;
    public float mySpeed;
    public float baseSpeed;
    NavMeshAgent agent;
    int currentWaypoint;
    public PatrolType patrolType;
    float detectDistance = 10;
    float detectTime = 5;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Setup()
    {
        switch (animalType)
        {
            case AnimalType.Rabbit:
                mySpeed = baseSpeed * 2;

                break;
            case AnimalType.Rat:
                mySpeed = baseSpeed;

                break;
            case AnimalType.Snake:
                mySpeed = baseSpeed / 1.5f;

                break;

        }
    }

        void SetNav()
    {
        currentWaypoint = Random.Range(0, _AIM.wayPoints.Length);
        agent.SetDestination(_AIM.wayPoints[currentWaypoint].position);
        ChangeSpeed(mySpeed);
    }

    void ChangeSpeed(float _speed)
    {
        agent.speed = _speed;
    }

    void Update()
    {
        float distToPlayer = Vector3.Distance(transform.position, _P.transform.position);
        if (distToPlayer <= detectDistance)
        {
           if (patrolType != PatrolType.Flee)
            {
                patrolType = PatrolType.Detect;
            }
        }

        switch (patrolType)
        {
            
            case PatrolType.Flee:
                agent.SetDestination(_AIM.burrows[Random.Range(0, _AIM.burrows.Length)].position);
                ChangeSpeed(mySpeed * 1.5f);
                if (distToPlayer > detectDistance)
                    patrolType = PatrolType.Detect;
                break;
            case PatrolType.Detect:
                agent.SetDestination(transform.position);
                ChangeSpeed(0);
                detectTime -= Time.deltaTime;
                if (detectTime <= 0)
                {
                    if (distToPlayer <= detectDistance)
                    {
                        patrolType = PatrolType.Flee;
                        detectTime = 5;
                        
                    }
                    else
                    {
                        patrolType = PatrolType.Patrol;
                        SetNav();
                    }
                }

                break;
            default:
                float distToWaypoint = Vector3.Distance(transform.position, _AIM.wayPoints[currentWaypoint].position);

                if (distToWaypoint < 1f)
                {
                    SetNav();
                }
                detectTime = 5;
                break;
        }
    }

    ////public float moveSpeed = 3f;
    //public float rotSpeed = 100f;

    //private bool isWandering = false;
    //private bool isRotatingLeft = false;
    //private bool isRotatingRight = false;
    //private bool isWalking = false;


    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    if(isWandering == false)
    //    {
    //        StartCoroutine(Wander());
    //    }
    //    if(isRotatingRight == true)
    //    {
    //        transform.Rotate(transform.up * Time.deltaTime * rotSpeed);
    //    }
    //    if (isRotatingLeft == true)
    //    {
    //        transform.Rotate(transform.up * Time.deltaTime * -rotSpeed);
    //    }
    //    if(isWalking == true)
    //    {
    //        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    //    }

    //}

    //IEnumerator Wander()
    //{
    //    int rotTime = Random.Range(1, 3);
    //    int rotateWait = Random.Range(3, 4);
    //    int rotateLorR = Random.Range(1, 2);
    //    int walkWait = Random.Range(1, 4);
    //    int walkTime = Random.Range(1, 5);

    //    isWandering = true;

    //    yield return new WaitForSeconds(walkWait);
    //    isWalking = true;
    //    yield return new WaitForSeconds(walkTime);
    //    isWalking = false;
    //    yield return new WaitForSeconds(rotateWait);
    //    if(rotateLorR == 1)
    //    {
    //        isRotatingRight = true;
    //        yield return new WaitForSeconds(rotTime);
    //        isRotatingRight = false;
    //    }
    //    if (rotateLorR == 2)
    //    {
    //        isRotatingLeft = true;
    //        yield return new WaitForSeconds(rotTime);
    //        isRotatingLeft = false;
    //    }
    //    isWandering = false;
    //}
}
