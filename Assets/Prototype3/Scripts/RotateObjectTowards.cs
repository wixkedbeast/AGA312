using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObjectTowards : MonoBehaviour
{
    public float speed = 5f;
    // Start is called before the first frame update
    private void Update()
    {
        Vector3 Direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
    }
}
