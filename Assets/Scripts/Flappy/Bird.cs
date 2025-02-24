using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    FlappyManager flappyManager = null;
    Rigidbody2D _rigidbody = null;

    public float flapForce = 6f;
    public float forwardSpeed = 3f;
    public bool isDead = false;
    float deathCooldown = 0;

    bool isFlap = false;

    public bool godMode = false;

    private void Start()
    {
        flappyManager = FlappyManager.Instance;
        _rigidbody = GetComponent<Rigidbody2D>();

        if ( _rigidbody == null )
        {
            Debug.LogError("Didn't find RigidBody2D");
        }
    }

    /// <summary>
    /// �׾����� ���� ����� / ��������� �÷�
    /// </summary>
    void Update()
    {
        if (isDead)
        { 
            if (deathCooldown <= 0f)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    flappyManager.RestartGame();
                }
            }
            else
            {
                deathCooldown -= Time.deltaTime;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isFlap = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (isDead) return;

        Vector3 velocity = _rigidbody.velocity;
        velocity.x = forwardSpeed;

        if (isFlap)
        {
            velocity.y += flapForce;
            isFlap = false;
        }

        _rigidbody.velocity = velocity;

        float angle = Mathf.Clamp((_rigidbody.velocity.y * 10f), -90, 90);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    /// <summary>
    /// ��ֹ��̳� õ�� / �ٴڿ� ������ ���
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (godMode) return;
        if (isDead) return;

        isDead = true;
        deathCooldown = 1f;
        flappyManager.GameOver();
    }
}
