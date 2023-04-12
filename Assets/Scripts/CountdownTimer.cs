using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public float countdownTime = 3.0f;
    private int countdownValue = 4;
    public Sprite[] countdownSprites;
    public Image countdownImage;

    public void countdowntrigger()
    {
        countdownImage = GameObject.Find("3").GetComponent<Image>();
        countdownImage.enabled = false;
        InvokeRepeating("Countdown", 0.0f, 1.0f);
    }

    public void Countdown()
    {
        countdownTime -= 1.0f;
        if (countdownTime <= 0.0f)
        {
            countdownValue--;
            Debug.Log("Countdown Value: " + countdownValue); // Debug print statement
            if (countdownValue == 0)
            {
                countdownImage.sprite = countdownSprites[3];
                countdownImage.enabled = true;
                // Start the game
                CancelInvoke("Countdown"); // cancel the repeated method calls
                Debug.Log("Countdown stopped.");
            }
            else
            {
                countdownImage.sprite = countdownSprites[countdownValue - 1];
                countdownImage.enabled = true;
            }
            countdownTime = 1.0f;
        }
        else
        {
            countdownImage.enabled = false;
        }
    }
}

