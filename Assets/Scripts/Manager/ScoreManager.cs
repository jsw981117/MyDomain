using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager instance;
    public const int LEADERBOARD_SIZE = 5; // �������忡 ������ �ִ� ���� ����
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
    /// �̴ϰ��ӿ��� �̱����� ���ھ� �Ŵ������ٰ� �������� ������ �������ݴϴ� + PlayerPrefs�� �����ϱ� ������ ������Ʈ�� ���� �ѵ� ������.
    /// </summary>
    /// <param name="miniGameName"></param>
    /// <param name="score"></param>
    public void SaveHighScore(string miniGameName, int score)
    {
        List<int> scores = GetLeaderboard(miniGameName);
        scores.Add(score);
        scores.Sort((a, b) => b.CompareTo(a)); // ���� �������� ���� (���� ���� �켱)

        while (scores.Count > LEADERBOARD_SIZE)
        {
            scores.RemoveAt(scores.Count - 1);
        }

        // PlayerPrefs�� ����
        for (int i = 0; i < scores.Count; i++)
        {
            PlayerPrefs.SetInt(miniGameName + "_Score_" + i, scores[i]);
        }
        PlayerPrefs.Save();
    }

    /// <summary>
    /// �������忡 ��ϵ� ������ ��� �����ɴϴ�.
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
    /// �ְ� ������ ��������
    /// </summary>
    /// <param name="miniGameName"></param>
    /// <returns></returns>
    public int GetHighScore(string miniGameName)
    {
        List<int> scores = GetLeaderboard(miniGameName);
        if (scores.Count > 0)
            return scores[0]; // ��������� ���ĵǾ� �����Ƿ� ù ��° ���� �ְ� ����!
        else
            return 0; // ����� ������ ������ 0 ��ȯ
    }
}
