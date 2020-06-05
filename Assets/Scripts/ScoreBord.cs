using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBord : MonoBehaviour
{
    int score = 0;
    Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
    }

    public void scoreHit(int receveScorePoints)
    {
        score = score + receveScorePoints;
        scoreText.text = score.ToString();
    }
}
