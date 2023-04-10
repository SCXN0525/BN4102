using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject PlayButton;

    public GameObject ReplayButton;

    public GrumpyBee player;

    public GameObject logo;

    private void Awake()
    {
        Application.targetFrameRate = 69;

        Pause();
    }

    public void Play()
    {
        PlayButton.SetActive(false);
        ReplayButton.SetActive(false);
        logo.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;
    }
    void Start() //start of new codes
    {

    }

    void Update()
    {

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
