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
        Debug.Log($"�� �����: {oldScene.name} �� {newScene.name}");

        // FlappyMainScene �� MainScene���� �̵��� �� �ְ� ���� ��������
        if (oldScene.name == "FlappyMainScene" && newScene.name == "MainScene")
        {
            int highScore = ScoreManager.Instance.GetHighScore("Flappy");
            Debug.Log($"Flappy �ְ� ����: {highScore}");

            // UI�� �ְ� ���� ������Ʈ�ϴ� �ڵ� (MainScene���� UI�� �ִٸ�)
            //MainSceneUI ui = FindObjectOfType<MainSceneUI>();
            //if (ui != null)
            //{
            //    ui.UpdateHighScore(highScore);
            //}
        }
    }
}
