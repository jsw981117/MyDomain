using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionHandler : MonoBehaviour
{
    private bool IsNearby = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            IsNearby = true;
            Debug.Log("F를 눌러 joy를 표하세요");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            IsNearby = false;
        }
    }

    public void Interact()
    {
        if (IsNearby)
        {
            Debug.Log("상호작용 되었음");
            // 이 아래에 상호작용 추가
        }
    }
}
