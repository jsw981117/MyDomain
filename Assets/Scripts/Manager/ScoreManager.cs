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

        if (score > bestScore) // ���� �ְ� �������� ũ�� ����
        {
            PlayerPrefs.SetInt(miniGameName + "_HighScore", score);
            PlayerPrefs.Save(); // ���� ���� ����
            Debug.Log($"���ο� �ְ� ���� ����! {miniGameName}: {score}");
        }
    }

    public int GetHighScore(string miniGameName)
    {
        return PlayerPrefs.GetInt(miniGameName + "_HighScore", 0);
    }
}
