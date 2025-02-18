using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FlappyUI : MonoBehaviour
{
    public TextMeshProUGUI currentScore;
    public TextMeshProUGUI restartText;

    void Start()
    {
        if (restartText == null)
            Debug.LogError("Restart txt is null");

        if (currentScore == null)
            Debug.LogError("Score txt is null");

        restartText.gameObject.SetActive(false);
    }

    public void SetRestart()
    {
        restartText.gameObject.SetActive(true);
    }

    public void UpdateScore(int score)
    {
        currentScore.text = score.ToString();
    }
}
