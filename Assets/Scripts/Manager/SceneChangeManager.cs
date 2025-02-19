using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour
{
    private void Awake()
    {
        SceneManager.activeSceneChanged += OnSceneChanged;
    }

    private void OnDestroy()
    {
        SceneManager.activeSceneChanged -= OnSceneChanged;
    }

    private void OnSceneChanged(Scene oldScene, Scene newScene)
    {
        Debug.Log($"씬 변경됨: {oldScene.name} ▶ {newScene.name}");

        // FlappyMainScene → MainScene으로 이동할 때 최고 점수 가져오기
        if (oldScene.name == "FlappyMainScene" && newScene.name == "MainScene")
        {
            int highScore = ScoreManager.Instance.GetHighScore("Flappy");
            Debug.Log($"Flappy 최고 점수: {highScore}");

            // UI에 최고 점수 업데이트하는 코드 (MainScene에서 UI가 있다면)
            //MainSceneUI ui = FindObjectOfType<MainSceneUI>();
            //if (ui != null)
            //{
            //    ui.UpdateHighScore(highScore);
            //}
        }
    }
}
