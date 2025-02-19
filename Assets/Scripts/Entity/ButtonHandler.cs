using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    ScoresUI scoresUI;
    public ScoresUI ScoresUI { get { return scoresUI; } }


    public void Awake()
    {
        scoresUI = FindAnyObjectByType<ScoresUI>();
    }
    public void OnClickStart() // FlappyMain -> FlappyGame
    {
        SceneManager.LoadScene("FlappyGameScene");
    }

    public void OnClickExit() // FlappyMain -> Main
    {
        ScoreManager.Instance.isBack = true;
        SceneManager.LoadScene("MainScene");
    }

    public void OnClickExitFlappy()
    {
        SceneManager.LoadScene("FlappyMainScene");
    }

    public void OnClickScore()
    {
        ScoresUI.ScoresPopup();
    }

    public void OnClickExitScore()
    {
        ScoresUI.ExitScoresPopup();
    }

    public void OnClickBoard()
    {
        ScoresUI.LeaderBoard();
    }

    public void OnClickExitLeaderBoard()
    {
        ScoresUI.ExitLeaderBoard();
    }

    public void OnClickExitScoreReturn()
    {
        ScoresUI.ExitScoreReturn();
    }
}
