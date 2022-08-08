using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Finally : MonoBehaviour
{
    Text final;
    int highScore = 0;

    void Start()
    {
        final = GetComponent<Text>();
    }

    void Update()
    {
        if(PlayerController.score < 0)
        {
            PlayerController.gameOver = true;
        }
        if (!PlayerController.gameOver)
        {
            if (highScore <= PlayerController.score)
                highScore = PlayerController.score;
        }
        if (PlayerController.gameOver)
        {
            if(highScore == 0) final.text = "Game \nOver !";
            if (highScore > 0) final.text = "Great Work !! \n Hightist Score : " + highScore;
        }
    }
}
