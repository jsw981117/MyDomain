using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPC_Flappy : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("Flappy");
        SceneManager.LoadScene("FlappyMainScene"); // 나중에 중간 씬으로 변경해야함
    }
}
