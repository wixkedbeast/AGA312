using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandMine : MonoBehaviour
{
    public GameObject Explosion;

    public GameObject mainObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject exp = Instantiate(Explosion, transform.position, transform.rotation);
        Destroy(exp, 2);
        Destroy(mainObject);
        
    }
}
