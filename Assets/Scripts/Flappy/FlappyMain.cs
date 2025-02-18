using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FlappyMain : MonoBehaviour
{
    public TextMeshProUGUI highScore;
    private void Start()
    {
        highScore.text = ScoreManager.Instance.GetHighScore("Flappy").ToString();
    }
}
