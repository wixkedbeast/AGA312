using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaSpawn : MonoBehaviour
{
    public GameObject objectToSpawn;
    public bool isTimer;

    public float timeToSpawn;
    private float currentTimeToSpawn;

    void Start()
    {
        currentTimeToSpawn = timeToSpawn;
    }

    void Update()
    {
        if(isTimer)
        {
            UpdateTimer();
        }


    }

    private void UpdateTimer()
    {
        Debug.Log(currentTimeToSpawn);

        if(currentTimeToSpawn > 0)
        {
            currentTimeToSpawn -= Time.deltaTime;
        }
        else
        {
            SpawnObject();
            currentTimeToSpawn = timeToSpawn;
        }
    }
    public void SpawnObject()
    {
        // Instantiate at position (0, 0, 0) and zero rotation.
        Instantiate(objectToSpawn, transform.position, transform.rotation);
    }
}
