using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager instance;
    public static ScoreManager Instance { get { return instance; } }

    private Dictionary<string, int> highScores = new Dictionary<string, int>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveHighScore(string miniGameName, int score)
    {
        int bestScore = GetHighScore(miniGameName);

        if (score > bestScore) // 기존 최고 점수보다 크면 갱신
        {
            PlayerPrefs.SetInt(miniGameName + "_HighScore", score);
            PlayerPrefs.Save(); // 변경 사항 저장
            Debug.Log($"새로운 최고 점수 저장! {miniGameName}: {score}");
        }
    }

    public int GetHighScore(string miniGameName)
    {
        return PlayerPrefs.GetInt(miniGameName + "_HighScore", 0);
    }
}
