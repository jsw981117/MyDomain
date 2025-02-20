using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// 쓰고보니까 MainScene의 모든 UI를 전부 담당하게 되어서 ScoreUI보다는 MainUI가 더 적절한 이름일 것 같습니다
/// </summary>
public class ScoresUI : MonoBehaviour
{
    public TextMeshProUGUI flappyHighScore;
    public GameObject scoresPopup;
    public GameObject scoresBtn;

    public GameObject leaderBoard;
    public GameObject leaderBoardBtn;

    public TextMeshProUGUI flappyLBS1; // flappyLeaderBoardScore1
    public TextMeshProUGUI flappyLBS2;
    public TextMeshProUGUI flappyLBS3;
    public TextMeshProUGUI flappyLBS4;
    public TextMeshProUGUI flappyLBS5;

    public TextMeshProUGUI flappyScoreReturn;
    public GameObject flappyReturn;


    void Start()
    {
        scoresPopup.SetActive(false);
        leaderBoard.SetActive(false);
        if (ScoreManager.Instance.isBack)
        {
            flappyScoreReturn.text = ScoreManager.Instance.GetHighScore("Flappy").ToString();
            flappyReturn.SetActive(true);
            ScoreManager.Instance.isBack = false;
        }
        else
        {
            flappyReturn.SetActive(false);
        }
    }


    public void ScoresPopup()
    {
        scoresPopup.SetActive(true);
        scoresBtn.SetActive(false);
        leaderBoard.SetActive(false);
        leaderBoardBtn.SetActive(true);
        flappyHighScore.text = ScoreManager.Instance.GetHighScore("Flappy").ToString();
    }

    public void ExitScoresPopup()
    {
        scoresPopup.SetActive(false);
        scoresBtn.SetActive(true);
    }

    public void LeaderBoard()
    {
        leaderBoard.SetActive(true);
        leaderBoardBtn.SetActive(false);
        scoresPopup.SetActive(false);
        scoresBtn.SetActive(true);

        List<int> flappyLeaderBoard = ScoreManager.Instance.GetLeaderboard("Flappy");

        flappyLBS1.text = flappyLeaderBoard[0].ToString();
        flappyLBS2.text = flappyLeaderBoard[1].ToString();
        flappyLBS3.text = flappyLeaderBoard[2].ToString();
        flappyLBS4.text = flappyLeaderBoard[3].ToString();
        flappyLBS5.text = flappyLeaderBoard[4].ToString();
    }

    public void ExitLeaderBoard()
    {
        leaderBoard.SetActive(false);
        leaderBoardBtn.SetActive(true);
    }

    public void ScoreReturn()
    {

        flappyReturn.SetActive(true);
    }

    public void ExitScoreReturn()
    {
        flappyReturn.SetActive(false);
    }
}
