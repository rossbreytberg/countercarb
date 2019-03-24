using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField]
    int score = 0;
    const string labelPrefix = "Score: ";

    void Start()
    {
        UpdateLabel();
    }

    public int GetScore()
    {
        return score;
    }

    public int GainPoints(int points)
    {
        score += points;
        UpdateLabel();
        return score;
    }

    void UpdateLabel()
    {
        GetComponent<Text>().text = labelPrefix + score;
    }
}
