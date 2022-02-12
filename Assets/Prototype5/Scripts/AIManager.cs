using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PatrolType
{
    Patrol,
    Detect,
    Flee
}

public enum AnimalType
{
    Rabbit, 
    Rat, 
    Snake

}

public class AIManager : Singleton<AIManager>
{
    public Transform[] wayPoints;
    public Transform[] burrows;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
