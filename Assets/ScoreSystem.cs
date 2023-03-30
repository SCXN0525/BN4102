using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    public static ScoreSystem instance;

    int PlayerScore;
    public TMP_Text ScoreText;
    public GameObject Player;

    private void Awake()
    {
        instance = this;
        Debug.Log("ScoreSystem instance created.");
    }

    // Start is called before the first frame update
    void Start()
    {
        //to ensure that the score always starts at 0
        PlayerScore = 0;
    }

    // Update is called once per frame
    public void UpdateScore()
    {
        //adds 10 points every time this method is run
        PlayerScore += 1;
        //Updates the UI to reflect the change in score
        ScoreText.text = "Score: " + PlayerScore.ToString();
        Debug.Log("Score updated: " + PlayerScore.ToString());
    }
}
