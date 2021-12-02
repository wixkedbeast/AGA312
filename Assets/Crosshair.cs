using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public GameObject crosshair;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = this.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
       

        crosshair.transform.position = new Vector3 (pos.x, pos.y, -9);

        print(this.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition));
           
    }
}
