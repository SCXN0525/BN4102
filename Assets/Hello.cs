using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hello : MonoBehaviour
{
    public float speed = 3.5f;
    public void SetEasyDifficulty()
    {
        speed = 2.5f; // Slower speed
        Debug.Log("Set easy");
    }

    public void SetMediumDifficulty()
    {
        speed = 3.5f; // Moderate speed
        Debug.Log("Set medium");
    }

    public void SetHardDifficulty()
    {
        speed = 4.5f; // Faster speed
        Debug.Log("Set hard");
    }
}
