using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour
{
    private static SceneChangeManager instance;

    private string previousSceneName = "";
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // ���� ����ŵ� ����
            SceneManager.activeSceneChanged += OnSceneChanged;
        }
        else
        {
            Destroy(gameObject); // �ߺ� ���� ����
        }
    }

    private void OnDisable()
    {
        SceneManager.activeSceneChanged -= OnSceneChanged;
    }

    public string GetPreviousSceneName()
    {
        return previousSceneName;
    }

    private void OnSceneChanged(Scene oldScene, Scene newScene)
    {
        Debug.Log($"�� �����: {oldScene.name} �� {newScene.name}");

        // FlappyMainScene �� MainScene���� �̵��� �� �ְ� ���� ��������
        if (oldScene.name == "FlappyMainScene" && newScene.name == "MainScene")
        {
            int highScore = ScoreManager.Instance.GetHighScore("Flappy");
            Debug.Log($"Flappy �ְ� ����: {highScore}");

            ScoresUI ui = FindObjectOfType<ScoresUI>();
            if (ui != null)
            {
                ui.ScoreReturn();
            }
        }
    }
}
