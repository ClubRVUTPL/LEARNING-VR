using System;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using TMPro;
using System.Collections;


public class ScoreUI : MonoBehaviour
{
    public TextMeshProUGUI leaderboardTextComponent;
    public ScoreManager scoreManager;
    public GameObject leaderboardPanel;

    void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            FirebaseApp app = FirebaseApp.DefaultInstance;
            DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
        });

        scoreManager.AddScore(new Score(name: FindObjectOfType<Script>().To.text, score: FindObjectOfType<Script>().quizManager.score));

        DatabaseReference scoresRef = FirebaseDatabase.DefaultInstance.RootReference.Child("scores");

        scoresRef.OrderByChild("score").LimitToLast(5).GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                Debug.LogError("Error al obtener puntajes: " + task.Exception.ToString());
                return;
            }

            DataSnapshot snapshot = task.Result;
            List<Score> scores = new List<Score>();

            foreach (DataSnapshot childSnapshot in snapshot.Children)
            {
                string json = childSnapshot.GetRawJsonValue();
                Score score = JsonUtility.FromJson<Score>(json);
                scores.Add(score);
            }

            scores.Sort((a, b) => b.score.CompareTo(a.score));

            UpdateLeaderboardText(scores);
        });

        StartCoroutine(ShowLeaderboardTextDelayed());
    }

    private IEnumerator ShowLeaderboardTextDelayed()
    {
        yield return new WaitForSeconds(10);
        leaderboardPanel.SetActive(true);
        scoreManager.DisplayLeaderboard();
    }

    public void MostrarRegistrosEnTextMeshPro()
    {
        scoreManager.DisplayLeaderboard();
    }

    void UpdateLeaderboardText(List<Score> scores)
    {
        string leaderboardText = "";

        for (int i = 0; i < scores.Count; i++)
        {
            leaderboardText += (i + 1) +"\t"+ scores[i].name+ "\t" + scores[i].score + "\t\n";
        }

        leaderboardTextComponent.text = leaderboardText;
    }
    

}
