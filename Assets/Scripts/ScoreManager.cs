using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using System.Threading.Tasks;

public class ScoreManager : MonoBehaviour
{
    public static DatabaseReference databaseReference;
    internal static object instance;

    public static List<ScoreData> nameScoreList { get; private set; }

    public static void collectionofdata()
    {
        // Initialize Firebase
        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;

        // Retrieve the data from Firebase
        databaseReference.Child("users").OrderByChild("score").GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                Debug.LogError("Failed to get data from Firebase: " + task.Exception);
                return;
            }

            // Convert the data to a list of ScoreData objects
            List<ScoreData> nameScoreList = new List<ScoreData>();
            foreach (DataSnapshot userSnapshot in task.Result.Children)
            {
                string name = userSnapshot.Child("name").Value.ToString();
                int score = int.Parse(userSnapshot.Child("score").Value.ToString());
                nameScoreList.Add(new ScoreData(name, score));
            }

            // Sort the list by score (in descending order)
            nameScoreList.Sort((x, y) => y.score.CompareTo(x.score));

            // Take only the top 5 entries
            nameScoreList = nameScoreList.GetRange(0, Mathf.Min(5, nameScoreList.Count));

            //Debug.Log(nameScoreList[1]);

            // Print the results to the console
            foreach (ScoreData entry in nameScoreList)
            {
                Debug.Log(entry.name + ": " + entry.score);
            }

            // Set the static property to the top 5 entries
            ScoreManager.nameScoreList = nameScoreList;
        });
    }

}

public class ScoreData
{
    public string userId;
    public string name;
    public int score;

    public ScoreData(string name, int score)
    {
        this.name = name;
        this.score = score;
    }
}





