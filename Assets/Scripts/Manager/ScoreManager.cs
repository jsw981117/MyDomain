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
        if (!highScores.ContainsKey(miniGameName) || highScores[miniGameName] < score)
        {
            highScores[miniGameName] = score;
            Debug.Log($"최고 점수 갱신! {miniGameName}: {score}");
        }
    }

    public int GetHighScore(string miniGameName)
    {
        return highScores.ContainsKey(miniGameName) ? highScores[miniGameName] : 0;
    }
}
