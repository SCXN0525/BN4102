using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighscoreTable : MonoBehaviour
{
    public Transform entryContainer;
    public Transform entryTemplate;

    private ScoreManager ScoreManager;
    private List<HighscoreEntry> highscoreEntryList;
    private List<Transform> highscoreEntryTransformList;

    private bool tableActivated = false;

    public void findindatabase()
    {
        entryContainer = transform.Find("HighscoreEntryContainer");
        entryTemplate = entryContainer.Find("HighscoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        ScoreManager = FindObjectOfType<ScoreManager>();
    }

    public IEnumerator WaitUntilNameScoreListIsPopulated()
    {
        while (ScoreManager.nameScoreList == null)
        {
            yield return null;
        }

        // Get the top 5 scores from the ScoreManager class
        List<ScoreData> scores = ScoreManager.nameScoreList;

        Debug.Log("List achieved");

        // Create a new list with only the necessary information
        if (scores != null)
        {
            highscoreEntryList = new List<HighscoreEntry>();
            foreach (ScoreData data in scores)
            {
                HighscoreEntry entry = new HighscoreEntry();
                entry.name = data.name;
                entry.score = data.score;
                highscoreEntryList.Add(entry);
            }
        }
        else
        {
            Debug.LogError("nameScoreList is null!");
        }

        // Sort the list by score (in descending order)
        highscoreEntryList.Sort((x, y) => y.score.CompareTo(x.score));

        // Loop through the highscoreEntryList and create UI elements for each entry
        highscoreEntryTransformList = new List<Transform>();
        int index = 0;
        foreach (HighscoreEntry highscoreEntry in highscoreEntryList)
        {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList, index);
            index++;
        }

        //Debug.Log(highscoreEntryList.Count);
        Debug.Log(highscoreEntryTransformList.Count);
    }

    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList, int index)
    {
        float templateHeight = 50f;
        Transform entryTransform = Instantiate(entryTemplate, entryContainer);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * index);
        entryTransform.gameObject.SetActive(true);

        int rank = index + 1;
        string rankString;
        switch (rank)
        {
            default:
                rankString = rank + "TH"; break;

            case 1: rankString = "1ST"; break;
            case 2: rankString = "2ND"; break;
            case 3: rankString = "3RD"; break;
        }

        entryTransform.Find("placeText").GetComponent<TextMeshProUGUI>().text = rankString;

        int score = highscoreEntry.score;

        //Debug.Log(score);

        entryTransform.Find("scoreText").GetComponent<TextMeshProUGUI>().text = score.ToString();

        string name = highscoreEntry.name;

        entryTransform.Find("nameText").GetComponent<TextMeshProUGUI>().text = name;
    }

    public void ActivateTable()
    {
        if (!tableActivated)
        {
            tableActivated = true;
            StartCoroutine(WaitUntilNameScoreListIsPopulated());
        }
    }

    private class HighscoreEntry
    {
        public int score;
        public string name;
    }
}
