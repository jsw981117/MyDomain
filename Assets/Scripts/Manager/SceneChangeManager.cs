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
            DontDestroyOnLoad(gameObject); // 씬이 변경돼도 유지
            SceneManager.activeSceneChanged += OnSceneChanged;
        }
        else
        {
            Destroy(gameObject); // 중복 생성 방지
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
        Debug.Log($"씬 변경됨: {oldScene.name} ▶ {newScene.name}");

        // FlappyMainScene → MainScene으로 이동할 때 최고 점수 가져오기
        if (oldScene.name == "FlappyMainScene" && newScene.name == "MainScene")
        {
            int highScore = ScoreManager.Instance.GetHighScore("Flappy");
            Debug.Log($"Flappy 최고 점수: {highScore}");

            ScoresUI ui = FindObjectOfType<ScoresUI>();
            if (ui != null)
            {
                ui.ScoreReturn();
            }
        }
    }
}
