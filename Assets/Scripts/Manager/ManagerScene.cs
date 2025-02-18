using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScene : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        StartCoroutine(LoadMainSceneAfterDelay(1f));
    }


    private IEnumerator LoadMainSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("MainScene");
    }
}
