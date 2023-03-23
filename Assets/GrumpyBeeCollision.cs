using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrumpyBeeCollision : MonoBehaviour
{
    private Color originalColor;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision detected!");
        if (other.gameObject.tag == "honeypot")
        {
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "brick")
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("brick"))
        {
            spriteRenderer.color = originalColor;
        }
    }
}
