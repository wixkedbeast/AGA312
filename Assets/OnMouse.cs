using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouse : MonoBehaviour
{
    public bool isCorrect;
    void OnMouseDown()
    {
        EquationsGenerator.instance.SetAnswer(isCorrect);
        gameObject.SetActive(false);
    }

    //when round start equation comes up on screen and plates will be thrown 
    //check to see if answer is correct if so complete round and get points 
    //if the wrong answer has been selected lose life 
    //whenever an answer is selected go to the next round
    //if you dont shoot anything you will also lose a life
    //if all lives lost game over 
    //if all rounds complete you win!
}
