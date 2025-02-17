using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatHandler : MonoBehaviour
{
    [Range(1f, 20f)][SerializeField] private float speed = 3; // 이동 속도
    public float Speed
    {
        get => speed; // 이동 속도를 가져올 때는 speed를 반환
        set => speed = Mathf.Clamp(value, 0, 20); // 이동 속도를 설정할 때는 0과 20 사이로 제한
    }
}
