using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;

public class GrumpyBeeCollision : MonoBehaviour
{
    private Color originalColor;
    private SpriteRenderer spriteRenderer;
    public int hearts = 3;
    public int score = 0;
    public Image[] heartImages;
    public GameObject gameover;
    public GameObject ReplayButton;
    public GameObject Scoreboard;
    public FirebaseManager FirebaseManager;
    public HighscoreTable HighscoreTable;
    public ScoreManager ScoreManager;
    public GameObject goImage; // new variable to reference the "GO!" image game object
    private bool hasCollidedWithBrick = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        UpdateHearts();
        gameover.SetActive(false);
        ReplayButton.SetActive(false);
        Scoreboard.SetActive(false);
        goImage.SetActive(false); // make sure the "GO!" image is initially inactive
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision detected!");
        if (other.gameObject.tag == "honeypot")
        {
            Destroy(other.gameObject);
            score++;
        }
        else if (other.gameObject.tag == "brick")
        {
            if (!hasCollidedWithBrick)
            {
                spriteRenderer.color = Color.red;
                hearts--;
                UpdateHearts();
                hasCollidedWithBrick = true;
                if (hearts == 0)
                {
                    GameOver();
                }
                else
                {
                    Invoke("ResetGame", 0.05f);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("brick") && hasCollidedWithBrick)
        {
            spriteRenderer.color = originalColor;
            hasCollidedWithBrick = false;
        }
    }

    void UpdateHearts()
    {
        for (int i = 0; i < heartImages.Length; i++)
        {
            if (i < hearts)
            {
                heartImages[i].enabled = true;
            }
            else
            {
                heartImages[i].enabled = false;
            }
        }
    }

    void GameOver()
    {
        gameover.SetActive(true);
        ReplayButton.SetActive(true);
        Time.timeScale = 0;
        Scoreboard.SetActive(true);
        ScoreManager.collectionofdata();
        HighscoreTable highscoreTable = FindObjectOfType<HighscoreTable>();
        if (highscoreTable != null)
        {
            highscoreTable.findindatabase();
            highscoreTable.ActivateTable();
        }
    }

    void RestartGame()
    {
        // Reset the game scene 
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
    public void ResetGame()
    {
        // Pause the game 
        Time.timeScale = 0;
        // Reset the Grumpy Bee's position to its initial position 
        transform.position = new Vector3(0, 0, 0);

        // Destroy any remaining honeypots and bricks 
        GameObject[] honeypots = GameObject.FindGameObjectsWithTag("honeypot");
        foreach (GameObject honeypot in honeypots)
        {
            Destroy(honeypot);
        }

        GameObject[] bricks = GameObject.FindGameObjectsWithTag("brick");
        foreach (GameObject brick in bricks)
        {
            Destroy(brick);
        }

        // Reset and update the hearts UI 
        UpdateHearts();

        // Reset the Grumpy Bee's color to its original color 
        spriteRenderer.color = originalColor;

        // Reset any other game state variables to their initial values 

        // Set the hasCollidedWithBrick flag to false 
        hasCollidedWithBrick = false;

        // Wait for 3 second and then resume the game 
        StartCoroutine(ResumeGameAfterDelay(3f));
    }
    private IEnumerator ResumeGameAfterDelay(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        // Show the "GO!" image 
        if (goImage != null)
        {
            goImage.SetActive(true);
        }
        Time.timeScale = 1;
        yield return new WaitForSeconds(2f); // add 2 second delay
        if (goImage != null)
        {
            goImage.SetActive(false); // deactivate the "GO!" image
        }
    }
}

