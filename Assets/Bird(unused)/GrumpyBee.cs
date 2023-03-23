using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrumpyBee : MonoBehaviour
{
    // speed at which it is moving
    public float speed = 1.5f;

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
}
