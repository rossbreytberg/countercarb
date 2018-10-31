using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeCounter : MonoBehaviour {

    [SerializeField]
    int lives = 3;
    const string labelPrefix = "Lives: ";

    void Start () {
        UpdateLabel();
    }

    public int LoseLife()
    {
        lives--;
        UpdateLabel();
        return lives;
    }

    void UpdateLabel()
    {
        GetComponent<Text>().text = labelPrefix + lives;
    }
}
