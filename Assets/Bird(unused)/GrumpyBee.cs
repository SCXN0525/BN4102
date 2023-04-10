using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrumpyBee : MonoBehaviour
{
    // speed at which it is moving
    public float speed = 1.5f;

    public GameObject easyButton;
    public GameObject mediumButton;
    public GameObject hardButton;

    public GameObject easyText;
    public GameObject mediumText;
    public GameObject hardText;
    public GameObject Instructions;
    public GameObject goBack;


    void Start()
    {
        easyText.SetActive(false);
        mediumText.SetActive(false);
        hardText.SetActive(false);
        Instructions.SetActive(false);
        goBack.SetActive(false);
    }
    public void SetEasyDifficulty()
    {
        speed = 0.5f; // Slower speed
        easyButton.SetActive(false); // Hide the easy difficulty button
        mediumButton.SetActive(false); // Hide the medium difficulty button
        hardButton.SetActive(false); // Hide the hard difficulty button
        easyText.SetActive(true);
    }

    public void SetMediumDifficulty()
    {
        speed = 1.5f; // Moderate speed
        easyButton.SetActive(false); // Hide the easy difficulty button
        mediumButton.SetActive(false); // Hide the medium difficulty button
        hardButton.SetActive(false); // Hide the hard difficulty button
        mediumText.SetActive(true);
    }

    public void SetHardDifficulty()
    {
        speed = 2.5f; // Faster speed
        easyButton.SetActive(false); // Hide the easy difficulty button
        mediumButton.SetActive(false); // Hide the medium difficulty button
        hardButton.SetActive(false); // Hide the hard difficulty button
        hardText.SetActive(true);
    }

    // Up and Down movement of the Bird using keypad - to be changed to syncing up with Arduino
    private void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
    }

    public void activateInstructions()
    {
        Instructions.SetActive(true);
        goBack.SetActive(true);
    }

    public void closeInstructions()
    {
        Instructions.SetActive(false);
        goBack.SetActive(false);
    }
}
