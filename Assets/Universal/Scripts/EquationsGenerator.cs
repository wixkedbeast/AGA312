using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EquationsGenerator : MonoBehaviour {

    [Header("UI")]
    public TMP_Text numberOneText;
    public TMP_Text numberTwoText;
    public TMP_Text message;
    public TMP_InputField answersField;
    public TMP_Text operatorText;

    public enum Difficulty {EASY, MEDIUM, HARD}
    public Difficulty difficulty;

    public int numberOne;
    public int numberTwo;
    public int correctAnswer;
    
    public List<int> dummyAnswers;

    void Start()
    {
        GenerateRandomEquation();
    }
    
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.M))
            GenerateMultiplication();
        if (Input.GetKeyDown(KeyCode.A))
            GenerateAddition();
        if (Input.GetKeyDown(KeyCode.D))
            GenerateDivision();


        if (Input.GetKeyDown(KeyCode.R))
            GenerateRandomEquation();

    }

    void GenerateNumbers()
    {
        numberOne = GetRandomNumbers();
        numberTwo = GetRandomNumbers();
        
        numberOneText.text = numberOne.ToString();
        numberTwoText.text = numberTwo.ToString();

    }

    void GenerateRandomEquation()
    {
        int rnd = Random.Range(1, 100);
        if (rnd <= 35)
            GenerateAddition();
        else if (rnd <= 60)
            GenerateSubtraction();
        else if (rnd <= 90)
            GenerateMultiplication();
        else
            GenerateDivision();
    }

    void GenerateMultiplication()
    {
        GenerateNumbers();
        operatorText.text = "*";
        correctAnswer = numberOne * numberTwo;
        Debug.Log(numberOne + " x " + numberTwo + " = " + correctAnswer);
        GenerateDummyAnswers(); 
    }

    void GenerateAddition()
    {
        GenerateNumbers();
        operatorText.text = "+";
        correctAnswer = numberOne + numberTwo;
        Debug.Log(numberOne + " + " + numberTwo + " = " + correctAnswer);
        GenerateDummyAnswers();
    }

    void GenerateSubtraction()
    {
        GenerateNumbers();
        operatorText.text = "-";
        correctAnswer = numberOne - numberTwo;
        Debug.Log(numberOne + " - " + numberTwo + " = " + correctAnswer);
        GenerateDummyAnswers();
    }

    void GenerateDivision()
    {
        GenerateNumbers();
        operatorText.text = "/";
        correctAnswer = numberOne / numberTwo;
        correctAnswer = Mathf.RoundToInt(correctAnswer);
        Debug.Log(numberOne + " / " + numberTwo + " = " + correctAnswer);
        GenerateDummyAnswers();
    }

    /// <summary>
    /// Gets a random number based on our difficulty
    /// </summary>
    /// <returns>A random number</returns>
    int GetRandomNumbers()
    {
        switch (difficulty)
        {
            case Difficulty.EASY:
                return (Random.Range(1, 10));
            case Difficulty.MEDIUM:
                return (Random.Range(1, 20));
            case Difficulty.HARD:
                return (Random.Range(1, 100));
            default:
                return (Random.Range(1, 10));
        }
    }

    /// <summary>
    /// This will generate a set of dummy answers
    /// </summary>
    private void GenerateDummyAnswers()
    {
        for (int i = 0; i < dummyAnswers.Count; i++)
        {
            int dummy;
            do
            {
                dummy = Random.Range(correctAnswer - 10, correctAnswer + 10);
            }
            while (dummy == correctAnswer || dummyAnswers.Contains(dummy));
            dummyAnswers[i] = dummy;
            Debug.Log("Dummy answer: " + dummyAnswers[i]);
        }
    }

    public void CheckAnswer(string _answer)
    {
        if (_answer == correctAnswer.ToString())
        {
            message.text = "Correct!";
            message.color = Color.yellow;
            

        }
        else
        {
            message.text = "Wrong!";
            message.color = Color.red;
        }
        GenerateRandomEquation();
        answersField.text = "";



    }
}
