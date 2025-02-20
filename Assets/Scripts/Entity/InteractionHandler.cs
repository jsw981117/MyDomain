using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 이 클래스를 NPC 오브젝트에 붙여줘야함
/// </summary>
public class InteractionHandler : MonoBehaviour
{
    private List<IInteractable> interactables = new List<IInteractable>(); // 인터페이스에서 상호작용한 객체들을 뽑아와서 저장해주는 리스트

    /// <summary>
    /// F키 누르면 상호작용
    /// </summary>
    private void Update()
    {
        if (Keyboard.current.fKey.wasPressedThisFrame && interactables.Count > 0)
        {
            interactables[0].Interact();
        }
    }

    /// <summary>
    /// 닿은 상호작용 가능한 NPC들을 리스트에 추가. Update에서 리스트의 가장 먼저 들어간 객체의 상호작용 이벤트만을 발생시키므로 먼저 닿은 NPC를 우선으로 상호작용함
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
