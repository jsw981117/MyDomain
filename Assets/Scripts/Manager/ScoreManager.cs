using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager instance;
    public const int LEADERBOARD_SIZE = 5; // 리더보드에 저장할 최대 점수 개수
    public static ScoreManager Instance { get { return instance; } }

    public bool isBack = false;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// 미니게임에서 싱글톤인 스코어 매니저에다가 리더보드 점수를 저장해줍니다 + PlayerPrefs에 저장하기 때문에 프로젝트를 껐다 켜도 유지됨.
    /// </summary>
    /// <param name="miniGameName"></param>
    /// <param name="score"></param>
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

    /// <summary>
    /// 리더보드에 등록된 점수를 모두 가져옵니다.
    /// </summary>
    /// <param name="miniGameName"></param>
    /// <returns></returns>
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

    /// <summary>
    /// 최고 점수만 가져오기
    /// </summary>
    /// <param name="miniGameName"></param>
    /// <returns></returns>
    public int GetHighScore(string miniGameName)
    {
        List<int> scores = GetLeaderboard(miniGameName);
        if (scores.Count > 0)
            return scores[0]; // 리더보드는 정렬되어 있으므로 첫 번째 값이 최고 점수!
        else
            return 0; // 저장된 점수가 없으면 0 반환
    }
}
