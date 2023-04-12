using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class PlayButton : MonoBehaviour
{
    SerialPort button_data = new SerialPort("COM4", 115200);
    public GameManager GameManager;

    void Start()
    {
        button_data.Open(); //Initialise serial stream
        button_data.ReadTimeout = 200; // In my case, 100 was a good amount to allow quite smooth transition. 
        Debug.Log("DS is open!");
    }

    // Update is called once per frame
    void Update()
    {
        if (button_data.IsOpen)
        {
            try
            {
                int buttonValue = button_data.ReadByte();
                // When green button is pushed

                if (buttonValue == 1)
                {
                    Debug.Log("Button pressed: " + buttonValue);
                    // transform.Translate(Vector3.left * Time.deltaTime * 5);
                    GameManager.Play();
                    // }
                    // if(buttonValue == 2){
                    //     Debug.Log("Button pressed: " + buttonValue);
                    //     PauseGame();
                    // }
                }
            }
            catch (System.Exception ex)
            {
                Debug.LogException(ex);
            }

        }
    }
}

