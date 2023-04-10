using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using System;

public class FirebaseManager : MonoBehaviour
{
    // Start is called before the first frame update

    DatabaseReference databaseReference;
    string userId;
    public ScoreSystem scoreScript;

    public GrumpyBee GrumpyBee;
    private string uuid;

    void Start()
    {
        uuid = Guid.NewGuid().ToString();
        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;

        Debug.Log("Database connected");
    }

    public void CreateNewUser()
    {
        //int finalscore = scorescript.score();

        scoreScript = GetComponent<ScoreSystem>();

        databaseReference.Child("users").Child(uuid).Child("name").SetValueAsync("John Doe");
        databaseReference.Child("users").Child(uuid).Child("score").SetValueAsync(scoreScript.score());
        //databaseReference.Child("users").Child(uuid).Child("difficulty").SetValueAsync(GrumpyBee.modetype());

        Debug.Log("New User Created");
    }
}
