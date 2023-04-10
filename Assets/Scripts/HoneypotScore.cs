using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoneypotScore : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("GrumpyBee"))
        {
            Debug.Log("Collision detected with Player1");
            ScoreSystem.instance.UpdateScore();
        }
        else if (other.gameObject.CompareTag("GreenBird"))
        {
            Debug.Log("Collision detected with Player2");
            ScoreSystem.instance.UpdateScore2();
        }
    }
}