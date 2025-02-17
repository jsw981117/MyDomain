using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatHandler : MonoBehaviour
{
    [Range(1f, 20f)][SerializeField] private float speed = 3; // �̵� �ӵ�
    public float Speed
    {
        get => speed; // �̵� �ӵ��� ������ ���� speed�� ��ȯ
        set => speed = Mathf.Clamp(value, 0, 20); // �̵� �ӵ��� ������ ���� 0�� 20 ���̷� ����
    }
}
