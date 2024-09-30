/*
* Kayden Miller
* Assignment 4
* Manages the players score and reseting on a gameover
*/

using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public PlayerControllerX pC;
    public int winScore;
    public Text scoreText;


    private int score;

    // Update is called once per frame
    void Update()
    {
        if (score == winScore)
        {
            pC.gameOver = true;
            scoreText.text = "You Win!\nPress R to restart";
        }
        else if(pC.gameOver && score < winScore)
        {
            scoreText.text = "Game Over!\nPress R to restart";
        }
        else
        {
            scoreText.text = "Score: " + score;
        }

        if(pC.gameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }


    public void addScore()
    {
        score++;
    }
}
