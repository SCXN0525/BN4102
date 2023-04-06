using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GrumpyBeeCollision : MonoBehaviour
{
    private Color originalColor;
    private SpriteRenderer spriteRenderer;
    public int hearts = 3;
    public Image[] heartImages;
    public GameObject gameOverMessage;
    public Transform startTransform; // Assign the start position of the Grumpy Bee to this variable
    private bool hasCollidedWithBrick = false;
    private int score = 0;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;

        int startingHearts = 3;
        hearts = startingHearts;

        int startingScore = 0; // Update starting score to be 0
        score = PlayerPrefs.GetInt("score", startingScore);

        UpdateHearts();
        gameOverMessage.SetActive(false);
        Debug.Log("Starting hearts: " + hearts);
        Debug.Log("Starting score: " + score);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision detected!");
        if (other.gameObject.tag == "honeypot")
        {
            Destroy(other.gameObject);
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
                    RestartGame();
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

    void RestartGame()
    {
        hearts--; // Subtract one heart from the player's remaining hearts
        PlayerPrefs.SetInt("hearts", hearts); // Save the updated hearts value to player prefs
        UpdateHearts(); // Update the hearts UI
        score = PlayerPrefs.GetInt("score", 0); // Update the score variable with the current score
        PlayerPrefs.SetInt("score", score); // Save the score to player prefs
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void GameOver()
    {
        PlayerPrefs.SetInt("score", score); // Save the final score to player prefs
        gameOverMessage.SetActive(true);
        Time.timeScale = 0;
    }
}