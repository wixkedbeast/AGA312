using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CheckpointManager : GameBehaviour
{
    public GameObject winPanel;
    public GameObject startPanel;
    public TMP_Text currentCheckpointText;
    public GameObject[] checkpoints;

    public GameObject[] totalCheckpoints;

    void Start()
    {
        Time.timeScale = 0;
        totalCheckpoints = GameObject.FindGameObjectsWithTag("Checkpoint");
    }

   
    void Update()
    {
        checkpoints = GameObject.FindGameObjectsWithTag("Checkpoint");

        currentCheckpointText.text = "Checkpoints: " + checkpoints.Length + " / " + totalCheckpoints.Length;

        if(checkpoints.Length < 1)
        {
            Time.timeScale = 0.5f;
            winPanel.SetActive(true);
        }


    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Title");
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("Prototype 5");
    }

    public void RunGame()
    {
        Time.timeScale = 1;
        startPanel.SetActive(false);
    }
}
