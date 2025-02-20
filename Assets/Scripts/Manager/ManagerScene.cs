using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScene : MonoBehaviour
{
    /// <summary>
    /// �Ŵ����� BootScene���� �ѹ��� �����ؼ� ���� ���鿡 �Ѱ��ݴϴ�.
    /// </summary>
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        StartCoroutine(LoadMainSceneAfterDelay(0.2f));
    }


    private IEnumerator LoadMainSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("MainScene");
    }
}
