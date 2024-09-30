/*
* Kayden Miller
* Assignment 4
* Manages displaying the user score and reloading the scene on a gameover
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;

    public PlayerController pC;

    public bool won = false;

    // Start is called before the first frame update
    void Start()
    {
        if(scoreText == null)
        {
            scoreText = FindObjectOfType<Text>();
        }

        if (pC == null )
        {
            pC = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        }

        scoreText.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        if (!pC.gameOver)
        {
            scoreText.text = "Score: " + score;
        }

        if (pC.gameOver && !won)
        {
            scoreText.text = "You Lose!\nPress R to try again!";
        }

        if(score>10)
        {
            pC.gameOver = true;
            won = true;

            scoreText.text = "You Win!\nPress R to try again!";
        }

        if(pC.gameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
