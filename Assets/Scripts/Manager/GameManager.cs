using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance { get { return instance; } }


    private void Start()
    {
        Application.targetFrameRate = 60;
        Debug.Log("GameManager Ω√¿€");
    }
}