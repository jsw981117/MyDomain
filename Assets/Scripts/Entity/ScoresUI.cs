using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoresUI : MonoBehaviour
{
    public TextMeshProUGUI flappyHighScore;
    public GameObject scoresPopup;
    public GameObject scoresBtn;

    void Start()
    {
        scoresPopup.SetActive(false);
    }


    public void ScoresPopup()
    {
        scoresPopup.SetActive(true);
        scoresBtn.SetActive(false);
        flappyHighScore.text = ScoreManager.Instance.GetHighScore("Flappy").ToString();
    }

    public void ExitScoresPopup()
    {
        scoresPopup.SetActive(false);
        scoresBtn.SetActive(true);
    }
}
