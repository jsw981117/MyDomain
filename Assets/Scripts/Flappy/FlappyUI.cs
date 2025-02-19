using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlappyUI : MonoBehaviour
{
    public TextMeshProUGUI currentScore;
    public TextMeshProUGUI restartText;
    public TextMeshProUGUI highScoreText;
    public GameObject highScore;
    public GameObject exitBtn;


    void Start()
    {
        if (restartText == null)
            Debug.LogError("Restart txt is null");

        if (currentScore == null)
            Debug.LogError("Score txt is null");

        restartText.gameObject.SetActive(false);
        exitBtn.SetActive(false);
        highScore.SetActive(false);
    }

    public void SetRestart()
    {
        Debug.Log("Á×À½");
        restartText.gameObject.SetActive(true);
        exitBtn.SetActive(true);
        highScore.SetActive(true);
        highScoreText.text = ScoreManager.Instance.GetHighScore("Flappy").ToString();
    }

    public void UpdateScore(int score)
    {
        currentScore.text = score.ToString();
    }
}
