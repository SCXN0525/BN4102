using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject PlayButton;

    public GameObject ReplayButton;

    public GrumpyBee player;

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
