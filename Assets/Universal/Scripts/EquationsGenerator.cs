using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EquationsGenerator : Singleton<EquationsGenerator> {

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

    public GameObject plate1;
    public GameObject plate2;
    public GameObject plate3;
    TMP_Text plate1Text;
    TMP_Text plate2Text;
    TMP_Text plate3Text;
    public int myScore = 50;
    int roundNumber = 0;
    float roundSpeed = 7;
    bool playerCorrect;
    public GameObject messagePanel;

    void Start()
    {
        plate1Text = plate1.GetComponentInChildren<TMP_Text>();
        plate2Text = plate2.GetComponentInChildren<TMP_Text>();
        plate3Text = plate3.GetComponentInChildren<TMP_Text>();
        //GenerateRandomEquation();
        StartCoroutine(LaunchPlates());
        
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
        operatorText.text = "x";
        correctAnswer = numberOne * numberTwo;
        Debug.Log(numberOne + " x " + numberTwo + " = " + correctAnswer);
        GenerateDummyAnswers();
        plate1Text.text = correctAnswer.ToString();
    }

    void GenerateAddition()
    {
        GenerateNumbers();
        operatorText.text = "+";
        correctAnswer = numberOne + numberTwo;
        Debug.Log(numberOne + " + " + numberTwo + " = " + correctAnswer);
        GenerateDummyAnswers();
        plate1Text.text = correctAnswer.ToString();
    }

    void GenerateSubtraction()
    {
        GenerateNumbers();
        operatorText.text = "-";
        correctAnswer = numberOne - numberTwo;
        Debug.Log(numberOne + " - " + numberTwo + " = " + correctAnswer);
        GenerateDummyAnswers();
        plate1Text.text = correctAnswer.ToString();
    }

    void GenerateDivision()
    {
        GenerateNumbers();
        operatorText.text = "/";
        correctAnswer = numberOne / numberTwo;
        correctAnswer = Mathf.RoundToInt(correctAnswer);
        Debug.Log(numberOne + " / " + numberTwo + " = " + correctAnswer);
        GenerateDummyAnswers();
        plate1Text.text = correctAnswer.ToString();
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
        plate2Text.text = dummyAnswers[0].ToString();
        plate3Text.text = dummyAnswers[1].ToString();
    }

    public void CheckAnswer(bool _answer)
    {
        if (_answer)
        {
            message.text = "Correct!";
            message.color = Color.yellow;
            ScoringSystem.instance.AddScore(myScore);
            

        }
        else
        {
            message.text = "Wrong!";
            message.color = Color.red;
            
        }
        
        

    }
    public void SetAnswer(bool _correct)
    {
        if(_correct)
        {
            //Add to score
            playerCorrect = true;  
        }
    }
    IEnumerator LaunchPlates()
    {
        playerCorrect = false;
        GenerateRandomEquation();
        plate1.SetActive(true);
        plate2.SetActive(true);
        plate3.SetActive(true);
        //Set plates to a random start pos 
        //add force in an upwards direction
        //round
        yield return new WaitForSeconds(roundSpeed);

        CheckAnswer(playerCorrect);
        yield return new WaitForSeconds(2);
        
        //answersField.text = "";
        if(roundNumber != 10)
        {
            roundNumber++;
            StartCoroutine(LaunchPlates());
        }
        else
        {
            //increment the set and then reset the round number and increment the force and speed 

        }
        
    }
}
