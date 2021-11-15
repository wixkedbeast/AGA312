using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public bool hasPizza = false;
    public GameObject pizza;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pizza"))
        {
            hasPizza = true;
            pizza.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PizzaCountdownRoutine());
        }
    }

    IEnumerator PizzaCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPizza = false;
        pizza.gameObject.SetActive(false);
    }
}
