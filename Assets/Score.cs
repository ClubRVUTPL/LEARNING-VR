using System;

[Serializable]
public class Score
{
    public string name;
    public float score;
    public string date;

    public Score(string name, float score)
    {
        this.name = name;
        this.score = score;
        this.date = DateTime.Now.ToString();
    }
}
