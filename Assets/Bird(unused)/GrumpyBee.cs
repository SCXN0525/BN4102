using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;

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

    SerialPort data_stream = new SerialPort("COM3", 115200); //Arduino is connected to COM6 with 115200 baud rate
    int potentiometerdata = 0;
    int potentiometerdata1;
    public Rigidbody rb;

    // Reference to the play button
    public Button playButton;

    // Flag to track whether a difficulty level has been selected
    public bool difficultySelected = false;

    public GameObject FireEasy;
    public GameObject FireMedium1;
    public GameObject FireMedium2;
    public GameObject FireHard1;
    public GameObject FireHard2;
    public GameObject FireHard3;

    void Start()
    {
        easyText.SetActive(false);
        mediumText.SetActive(false);
        hardText.SetActive(false);
        Instructions.SetActive(false);
        goBack.SetActive(false);
        data_stream.Open();

        // Disable the play button initially
        playButton.interactable = false;
    }
    public void SetEasyDifficulty()
    {
        speed = 0.5f; // Slower speed
        easyButton.SetActive(false); // Hide the easy difficulty button
        mediumButton.SetActive(false); // Hide the medium difficulty button
        hardButton.SetActive(false); // Hide the hard difficulty button
        easyText.SetActive(true);

        // Set the difficulty selected flag to true
        difficultySelected = true;

        // Enable the play button if a difficulty level has been selected
        playButton.interactable = difficultySelected;
        FireEasy.SetActive(false);
        FireMedium1.SetActive(false);
        FireMedium2.SetActive(false);
        FireHard1.SetActive(false);
        FireHard2.SetActive(false);
        FireHard3.SetActive(false);
    }

    public void SetMediumDifficulty()
    {
        speed = 1.5f; // Moderate speed
        easyButton.SetActive(false); // Hide the easy difficulty button
        mediumButton.SetActive(false); // Hide the medium difficulty button
        hardButton.SetActive(false); // Hide the hard difficulty button
        mediumText.SetActive(true);

        // Set the difficulty selected flag to true
        difficultySelected = true;

        // Enable the play button if a difficulty level has been selected
        playButton.interactable = difficultySelected;
        FireEasy.SetActive(false);
        FireMedium1.SetActive(false);
        FireMedium2.SetActive(false);
        FireHard1.SetActive(false);
        FireHard2.SetActive(false);
        FireHard3.SetActive(false);
    }

    public void SetHardDifficulty()
    {
        speed = 2.5f; // Faster speed
        easyButton.SetActive(false); // Hide the easy difficulty button
        mediumButton.SetActive(false); // Hide the medium difficulty button
        hardButton.SetActive(false); // Hide the hard difficulty button
        hardText.SetActive(true);

        // Set the difficulty selected flag to true
        difficultySelected = true;

        // Enable the play button if a difficulty level has been selected
        playButton.interactable = difficultySelected;
        FireEasy.SetActive(false);
        FireMedium1.SetActive(false);
        FireMedium2.SetActive(false);
        FireHard1.SetActive(false);
        FireHard2.SetActive(false);
        FireHard3.SetActive(false);
    }

    // Up and Down movement of the Bird using keypad - to be changed to syncing up with Arduino
    private void Update()
    {
        float moveY = 0f; // variable to store the amount of movement in the Y direction

        if (data_stream.IsOpen)
        {
            string data = data_stream.ReadLine();

            potentiometerdata1 = int.Parse(data); //read serial data
            // Debug.Log(potentiometerdata1);

            //track change in potentiometer data to move the bee

            if (potentiometerdata1 > potentiometerdata)
            {
                transform.position += Vector3.down * (potentiometerdata1 - potentiometerdata) * speed * Time.deltaTime;
                // Debug.Log("down" + potentiometerdata1 + ',' + potentiometerdata);
            }

            else if (potentiometerdata1 < potentiometerdata)
            {
                transform.position += Vector3.up * (potentiometerdata - potentiometerdata1) * speed * Time.deltaTime;
                // Debug.Log("up" + (potentiometerdata1-potentiometerdata));
            }

            potentiometerdata = potentiometerdata1;
            // Debug.Log("new potentiometer data: " + potentiometerdata);


        }

        else
        {

            if (Input.GetKey(KeyCode.UpArrow))
            {
                moveY = speed * Time.deltaTime; // move up
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                moveY = -speed * Time.deltaTime; // move down
            }
        }

        Vector3 newPosition = transform.position + new Vector3(0f, moveY, 0f); // calculate new position after movement

        // restrict the bee's movement within the scene boundaries
        if (newPosition.y > 3.5f)
        {
            newPosition.y = 3.5f; // set the bee's position to the top boundary
        }
        else if (newPosition.y < -3.5f)
        {
            newPosition.y = -3.5f; // set the bee's position to the bottom boundary
        }

        transform.position = newPosition; // update the bee's position
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
