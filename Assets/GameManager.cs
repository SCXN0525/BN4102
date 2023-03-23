using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject PlayButton;

    public GameObject ReplayButton;

    public GrumpyBee player;

    public Text scoreText; //new code line 1

    private int score; //new code line 2

    private void Awake()
    {
        Application.targetFrameRate = 69;

        Pause();
    }

    public void Play()
    {
        PlayButton.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;
    }
    void Start() //start of new codes
    {
        score = 0;
    }

    void Update()
    {
        // Detect when the player earns points
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddPoints(1); // Add 1 point to the score
        }
    }

    // Add points to the score and update the score text
    void AddPoints(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = "Score: " + score.ToString();
    } //end of new codes

    public void GameOver()
    {
        Pause();
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }
}
