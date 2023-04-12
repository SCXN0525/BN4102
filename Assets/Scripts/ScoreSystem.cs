using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;


public class ScoreSystem : MonoBehaviour
{
    public static ScoreSystem instance;

    public int PlayerScore;
    public int PlayerScore2;
    public TMP_Text ScoreText;
    public TMP_Text ScoreText2;

    public GameObject Player;
    public GameObject Player2;

    public GameObject bronze;
    public GameObject silver;
    public GameObject gold;

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
        PlayerScore2 = 0;
        bronze.SetActive(false);
        silver.SetActive(false);
        gold.SetActive(false);
    }

    // Update is called once per frame
    public void UpdateScore()
    {
        //adds 1 points every time this method is run
        PlayerScore += 1;
        //Updates the UI to reflect the change in score
        ScoreText.text = "Score: " + PlayerScore.ToString();
        Debug.Log("Score updated: " + PlayerScore.ToString());

        showbronze();
        showsilver();
        showgold();
    }

    public void UpdateScore2()
    {
        //adds 1 points every time this method is run
        PlayerScore2 += 1;
        //Updates the UI to reflect the change in score
        ScoreText2.text = "Player2 Score: " + PlayerScore2.ToString();
        Debug.Log("Score updated: " + PlayerScore2.ToString());
    }

    public int score()
    {
        return PlayerScore;
    }

    public int score2()
    {
        return PlayerScore2;
    }

    public void showbronze()
    {
        if (score() > 4)
        {
            bronze.SetActive(true);
        }
    }
    public void showsilver()
    {
        if (score() > 8)
        {
            silver.SetActive(true);
        }
    }
    public void showgold()
    {
        if (score() > 12)
        {
            gold.SetActive(true);
        }
    }
}
