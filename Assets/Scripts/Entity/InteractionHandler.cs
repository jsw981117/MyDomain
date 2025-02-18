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
            Debug.Log("F�� ���� joy�� ǥ�ϼ���");
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
            Debug.Log("��ȣ�ۿ� �Ǿ���");
            // �� �Ʒ��� ��ȣ�ۿ� �߰�
        }
    }
}
