using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotRotation : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public Rigidbody p_Rigidbody;
    Vector3 m_EulerAngleVelocity;
    Vector3 p_EulerAngleVelocity;
    public float speed = 10;
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float y = Input.GetAxisRaw("Horizontal") * speed;
        m_EulerAngleVelocity = new Vector3(0, y, 0);
        Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.fixedDeltaTime);
        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * deltaRotation);

        p_EulerAngleVelocity = new Vector3(0, y, 0);
        Quaternion delta = Quaternion.Euler(p_EulerAngleVelocity * Time.fixedDeltaTime);
        p_Rigidbody.MoveRotation(p_Rigidbody.rotation * delta);
    }
}
