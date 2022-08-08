using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    Text scoreText;

    void Start()
    {
        scoreText = GetComponent<Text>();
    }

    void Update()
    {
        if (!PlayerController.gameOver)
        {
            scoreText.text = "Score : " + PlayerController.score;
        } 
    }
}
