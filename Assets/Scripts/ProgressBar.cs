using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public GameObject gameover;
    public GameObject ReplayButton;
    public GameObject Scoreboard;
    public Slider progressBar;
    public float timeRemaining = 40.0f;

    void Update()
    {
        timeRemaining -= Time.deltaTime; // Subtract the time passed since the last frame from the time remaining
        float progress = 1.0f - timeRemaining / 30.0f; // Calculate the progress as a percentage of the total time
        progressBar.value = progress; // Update the slider's value

        if (timeRemaining <= 0.0f)
        {
            // Stop the game
            Time.timeScale = 0.0f;
            gameover.SetActive(true);
            ReplayButton.SetActive(true);

            Scoreboard.SetActive(true);
            ScoreManager.collectionofdata();

            HighscoreTable highscoreTable = FindObjectOfType<HighscoreTable>();
            if (highscoreTable != null)
            {
                highscoreTable.findindatabase();
                highscoreTable.ActivateTable();
            }
        }
    }
}
