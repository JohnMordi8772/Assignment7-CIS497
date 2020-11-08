/*
John Mordi
Assignment #7
Manages win/loss variables and conditions
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinLossManagerX : MonoBehaviour
{
    public Text winLossText;
    public static bool gameOver, win, gameStart;
    public static float enemyScored;

    void Start()
    {
        gameOver = false;
        win = false;
        gameStart = false;
        enemyScored = -1;
        StartCoroutine(Conditions());
    }

    IEnumerator Conditions()
    {
        winLossText.alignment = TextAnchor.MiddleCenter;
        winLossText.fontSize = 30;
        winLossText.text = "Win/Loss Conditions:\nYou lose if all enemies make it into your goal.\n\nYou win if you are able to knock all ten waves into the enemy goal." +
            "\nPress the SPACEBAR to begin.";

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        winLossText.alignment = TextAnchor.UpperLeft;
        winLossText.fontSize = 20;

        gameStart = true;

        yield break;
    }

    void Update()
    {
        if (gameOver)
        {
            if (win)
            {
                winLossText.alignment = TextAnchor.MiddleCenter;
                winLossText.fontSize = 30;
                winLossText.text = "Congratulations!\nYou Win!\n(Press R to play again)";
            }
            else
            {
                winLossText.alignment = TextAnchor.MiddleCenter;
                winLossText.fontSize = 30;
                winLossText.text = "Sorry, you lost.\n(Press R to try again)";
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                winLossText.alignment = TextAnchor.UpperLeft;
                winLossText.fontSize = 14;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

    }
}

