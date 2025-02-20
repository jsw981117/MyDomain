using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScene : MonoBehaviour
{
    /// <summary>
    /// 매니저를 BootScene에서 한번에 생성해서 다음 씬들에 넘겨줍니다.
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
