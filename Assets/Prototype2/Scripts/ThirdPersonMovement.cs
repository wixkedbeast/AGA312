using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    
    public float speed = 6f;
    public float turnSmoothTime = 0.0f;
    float turnSmoothVelocity;

    public Vector3 collision = Vector3.zero;

   

    // Update is called once per frame

    CharacterController charCtrl;

    void Start()
    {
        charCtrl = GetComponent<CharacterController>();
        
    }

   

    void Update()
    {
        if(Input.GetMouseButtonDown(0)) //allows interaction
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {

                Debug.Log(hit.transform.name);
                if (hit.transform.name == "Mine")
                {
                   //allows player to raycast to see if there is soil 
                }
            }
            
        }

       

        
        
        

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            controller.Move(direction * speed * Time.deltaTime);
            //moves player in third person using cinemachine to implement in the game 
        }

       
    }

    
    
}
