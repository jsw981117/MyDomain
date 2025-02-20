using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private static readonly int IsMove = Animator.StringToHash("IsMove"); // 성능 최적화

    protected Animator anim;

    protected virtual void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    public void MoveAnim(Vector2 obj)
    {
        anim.SetBool(IsMove, obj.magnitude > .5f);
    }
}
