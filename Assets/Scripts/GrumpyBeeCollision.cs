using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrumpyBeeCollision : MonoBehaviour
{
    private Color originalColor;
    private SpriteRenderer spriteRenderer;
    public int hearts = 3;
    public Image[] heartImages;
    public GameObject gameOverMessage;

    private bool hasCollidedWithBrick = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        UpdateHearts();
        gameOverMessage.SetActive(false);
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
        gameOverMessage.SetActive(true);
        Time.timeScale = 0;
    }
}

