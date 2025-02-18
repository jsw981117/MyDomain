using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public void OnClickStart()
    {
        SceneManager.LoadScene("FlappyGameScene");
    }

    public void OnClickExit()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OnClickExitFlappy()
    {
        SceneManager.LoadScene("FlappyMainScene");
    }
}
