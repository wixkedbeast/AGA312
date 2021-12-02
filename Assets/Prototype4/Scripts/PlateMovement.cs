using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateMovement : MonoBehaviour
{
    

    float xPos;
    float yVel;
    float xVel;
    // Start is called before the first frame update
    void Start()
    {
        xPos = Random.Range(-7, 7);
        yVel = Random.Range(9, 14);
        xVel = Random.Range(-4, 4);
    }

    // Update is called once per frame
    void Update()
    {
       

        if (this.transform.position.y < -6)
        {
            xPos = Random.Range(-7, 7);
            this.transform.position = new Vector3(xPos, -6);

            this.GetComponent<Rigidbody>().velocity = new Vector3(0f, yVel);
        }
    }
}
