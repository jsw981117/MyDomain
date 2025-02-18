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
    Bird bird;

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

    public void GameOver()
    {
        Debug.Log("Game Over");
    }

    public void StartGame()
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
