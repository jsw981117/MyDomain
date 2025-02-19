using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager instance;
    public const int LEADERBOARD_SIZE = 5; // 리더보드에 저장할 최대 점수 개수
    public static ScoreManager Instance { get { return instance; } }

    public bool isBack = false;

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
        List<int> scores = GetLeaderboard(miniGameName);
        scores.Add(score);
        scores.Sort((a, b) => b.CompareTo(a)); // 점수 내림차순 정렬 (높은 점수 우선)

        while (scores.Count > LEADERBOARD_SIZE)
        {
            scores.RemoveAt(scores.Count - 1);
        }

        // PlayerPrefs에 저장
        for (int i = 0; i < scores.Count; i++)
        {
            PlayerPrefs.SetInt(miniGameName + "_Score_" + i, scores[i]);
        }
        PlayerPrefs.Save();
    }

    public List<int> GetLeaderboard(string miniGameName)
    {
        List<int> scores = new List<int>();
        for (int i = 0; i < LEADERBOARD_SIZE; i++)
        {
            if (PlayerPrefs.HasKey(miniGameName + "_Score_" + i))
            {
                scores.Add(PlayerPrefs.GetInt(miniGameName + "_Score_" + i));
            }
        }
        return scores;
    }

    public int GetHighScore(string miniGameName)
    {
        List<int> scores = GetLeaderboard(miniGameName);
        if (scores.Count > 0)
            return scores[0]; // 리더보드는 정렬되어 있으므로 첫 번째 값이 최고 점수!
        return 0; // 저장된 점수가 없으면 0 반환
    }
}
