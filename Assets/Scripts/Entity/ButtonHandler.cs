using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 버튼 클릭 시 메서드 모아놓음. 실제로 이렇게 관리하는지는 모르겠습니다.
/// </summary>
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

    /// <summary>
    /// FlappyMainScene에서 MainScene으로 돌아왔을 때만 MainScene에서 결과창을 출력해야함
    /// </summary>
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
