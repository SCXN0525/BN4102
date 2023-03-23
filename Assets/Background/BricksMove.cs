using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BricksMove : MonoBehaviour
{
    public float speed = 3.5f;

    private float leftEdge;

    private void Start()
    {
        Debug.Log("Move in");
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    private void Update()
    {
        Debug.Log("Moving");
        transform.position += Vector3.left * speed * Time.deltaTime;
        
        if (transform.position.x < leftEdge){
            Destroy(gameObject);
        }
    }

}