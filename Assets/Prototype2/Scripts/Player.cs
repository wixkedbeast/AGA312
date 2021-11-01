using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    public int health;
    
    
    private int currentHealth;
    public HealthBar HP;
    public GameObject menuContainer;
    int damage = 10;

    private void Start()
    {
        currentHealth = health;
        HP.SetMaxHealth(health);

    }

   

    

    void Update()
    {
        
    }


    void OnCollisionEnter(Collision _collision)
    {
        if (_collision.gameObject.tag == "Land Mine")
        {
            currentHealth -= damage;
            
            HP.SetHealth(health);
            

        }
       
    }
}
