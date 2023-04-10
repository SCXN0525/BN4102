using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwo : MonoBehaviour
{
    // speed at which it is moving
    public float speed = 1.5f;

    public void SetEasyDifficulty()
    {
        speed = 0.5f; // Slower speed
    }

    public void SetMediumDifficulty()
    {
        speed = 1.5f; // Moderate speed
    }

    public void SetHardDifficulty()
    {
        speed = 2.5f; // Faster speed
    }

    // Up and Down movement of the Bird using keypad - to be changed to syncing up with Arduino
    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
    }
}
