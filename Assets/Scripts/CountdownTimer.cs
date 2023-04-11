using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public float countdownTime = 3;
    public Text countdownText;
    public GrumpyBeeCollision grumpyBeeCollision;

    private void Start()
    {
        countdownText.text = "3";
    }

    private void Update()
    {
        if (countdownTime > 0)
        {
            countdownTime -= Time.deltaTime;
            countdownText.text = Mathf.Round(countdownTime).ToString();
        }
        else if (countdownTime <= 0 && countdownText.text != "GO!")
        {
            countdownText.text = "GO!";
            grumpyBeeCollision.ResetGame();
            countdownText.text = "";
            countdownTime = 3;
        }
    }
}

