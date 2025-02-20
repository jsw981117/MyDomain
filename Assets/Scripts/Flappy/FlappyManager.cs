using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlappyManager : MonoBehaviour
{
    static FlappyManager flappyManager;

    public static FlappyManager Instance { get { return flappyManager; } }
    private int currentScore = 0;

    FlappyUI flappyUI;
    public FlappyUI FlappyUI { get { return flappyUI; } }


    private void Awake()
    {
        flappyManager = this;
        flappyUI = FindAnyObjectByType<FlappyUI>();
    }
    private void Start()
    {
        flappyUI.UpdateScore(0);
    }

    /// <summary>
    /// 게임 종료 시 현재 점수를 스코어매니저에다가 전달합니다. 전달된 점수는 리더보드랑 비교해서 높은 점수들만 남게 됩니다.
    /// </summary>
    public void GameOver()
    {
        Debug.Log("Game Over");

        ScoreManager.Instance.SaveHighScore("Flappy", currentScore);

        flappyUI.SetRestart();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddScore(int score)
    {
        currentScore += score;
        Debug.Log("Score: " + currentScore);
        flappyUI.UpdateScore(currentScore);
    }
}
