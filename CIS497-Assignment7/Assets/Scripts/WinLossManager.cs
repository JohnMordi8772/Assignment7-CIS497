/*
John Mordi
Assignment #7
Manages the win/loss variables and conditions
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinLossManager : MonoBehaviour
{
    public Text winLossText;
    public static bool gameOver, win, gameStart;

    void Start()
    {
        gameOver = false;
        win = false;
        gameStart = false;
        StartCoroutine(Conditions());
    }

    IEnumerator Conditions()
    {
        winLossText.alignment = TextAnchor.MiddleCenter;
        winLossText.fontSize = 40;
        winLossText.text = "Win/Loss Conditions:\nYou lose if fall off the platform.\n\nYou win if you are able to knock all ten waves of enemies off the platform." +
            "\nPress the SPACEBAR to begin.";

        while(!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        winLossText.alignment = TextAnchor.UpperLeft;
        winLossText.fontSize = 14;

        gameStart = true;

        yield break;
    }
    
    void Update()
    {
        if(gameOver)
        {
            if(win)
            {
                winLossText.alignment = TextAnchor.MiddleCenter;
                winLossText.fontSize = 40;
                winLossText.text = "Congratulations!\nYou Win!\n(Press R to play again)";
            }
            else
            {
                winLossText.alignment = TextAnchor.MiddleCenter;
                winLossText.fontSize = 40;
                winLossText.text = "Sorry, you lost.\n(Press R to try again)";
            }
            if(Input.GetKeyDown(KeyCode.R))
            {
                winLossText.alignment = TextAnchor.UpperLeft;
                winLossText.fontSize = 14;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        
    }
}
