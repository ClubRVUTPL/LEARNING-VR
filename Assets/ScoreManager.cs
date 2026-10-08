using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using UnityEngine;
using System;
using System.Collections.Generic;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private DatabaseReference reference;
    public TextMeshProUGUI leaderboardTextComponent;
    public Sprite medalSprite; // Nuevo campo para la medalla

    void Awake()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            FirebaseApp app = FirebaseApp.DefaultInstance;
            reference = FirebaseDatabase.DefaultInstance.RootReference.Child("scores");
        });
    }

    public void AddScore(Score score)
    {
        score.date = DateTime.Now.ToString();
        string json = JsonUtility.ToJson(score);
        reference.Push().SetRawJsonValueAsync(json);
        Debug.Log("Registro de puntuación agregado: Nombre - " + score.name + ", Puntuación - " + score.score);
    }

    public void DisplayLeaderboard()
    {
        Sprite medalSprite = Resources.Load<Sprite>("Medal");
        if (medalSprite != null)
        {
            Debug.Log("Sprite cargado correctamente");
        }
        else
        {
            Debug.LogError("No se pudo cargar el sprite");
        }

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

            string leaderboardText = "";

            for (int i = 0; i < scores.Count; i++)
            {
                string rank = (i + 1).ToString();
                string name = scores[i].name;
                string scoreValue = scores[i].score.ToString();
                string medal = "";

                if (i < 3)
                {
                    medal = "<sprite name=Medal>"; // Rich Text para el sprite de la medalla
                }

                leaderboardText += $"{rank}\t{name}\t{scoreValue}\t{medal}\t\n";
            }

            leaderboardTextComponent.text = leaderboardText;
        });
    }
}