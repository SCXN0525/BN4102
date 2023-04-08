using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class GrumpyBee : MonoBehaviour
{
    SerialPort data_stream = new SerialPort("COM6", 115200); //Arduino is connected to COM6 with 115200 baud rate
    int potentiometerdata = 0;
    int potentiometerdata1;
    public Rigidbody rb;

    // speed at which it is moving
    public float speed = 1.5f;

    //called before the first frame update
    void Start()
    {
        data_stream.Open(); //initialise serial stream
    }


    private void Update()
    {
        potentiometerdata1 = int.Parse(data_stream.ReadLine()); //read serial data
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
}
