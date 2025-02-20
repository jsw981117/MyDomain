using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// �� Ŭ������ NPC ������Ʈ�� �ٿ������
/// </summary>
public class InteractionHandler : MonoBehaviour
{
    private List<IInteractable> interactables = new List<IInteractable>(); // �������̽����� ��ȣ�ۿ��� ��ü���� �̾ƿͼ� �������ִ� ����Ʈ

    /// <summary>
    /// FŰ ������ ��ȣ�ۿ�
    /// </summary>
    private void Update()
    {
        if (Keyboard.current.fKey.wasPressedThisFrame && interactables.Count > 0)
        {
            interactables[0].Interact();
        }
    }

    /// <summary>
    /// ���� ��ȣ�ۿ� ������ NPC���� ����Ʈ�� �߰�. Update���� ����Ʈ�� ���� ���� �� ��ü�� ��ȣ�ۿ� �̺�Ʈ���� �߻���Ű�Ƿ� ���� ���� NPC�� �켱���� ��ȣ�ۿ���
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        IInteractable interactable = other.GetComponent<IInteractable>();
        if (interactable != null && !interactables.Contains(interactable))
        {
            interactables.Add(interactable);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        IInteractable interactable = other.GetComponent<IInteractable>();
        if (interactable != null)
        {
            interactables.Remove(interactable);
        }
    }
}
