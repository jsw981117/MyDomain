using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPC_Flappy : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("Flappy");
        SceneManager.LoadScene("FlappyMainScene");
    }
}
