using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public float lifeTime = 1;
    public int myScore = 50;

    private void OnTriggerStay(Collider other)
    {
        lifeTime -= Time.deltaTime;
        if(lifeTime <= 0)
        {
            ScoringSystem.instance.AddScore(myScore);
            Destroy(this.gameObject);
        }
    }
   
}
