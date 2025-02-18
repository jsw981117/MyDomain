using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    FlappyManager flappyManager;

    // ��ֹ��� �ִ� �� �ּ� y
    public float highPosY = 1f;
    public float lowPosY = -1f;

    // ������ �ּ� �� �ִ� ũ��
    public float holeSizeMin = 4f;
    public float holeSizeMax = 7f;


    public Transform topObject;
    public Transform bottomObject;

    // ��ֹ� ���� ���� ����
    public float widthPadding = 8f;

    private void Start()
    {
        flappyManager = FlappyManager.Instance;
    }

    public Vector3 SetRandomPlace(Vector3 lastPosition, int obstacleCount)
    {
        float holeSize = Random.Range(holeSizeMin, holeSizeMax);
        float halfHoleSize = holeSize / 2;

        topObject.localPosition = new Vector3(0, halfHoleSize);
        bottomObject.localPosition = new Vector3(0, -halfHoleSize);

        Vector3 placePosition = lastPosition + new Vector3(widthPadding, 0, 0);
        placePosition.y = Random.Range(lowPosY, highPosY);

        transform.position = placePosition;

        return placePosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bird bird = collision.GetComponent<Bird>();
        if (bird != null || bird.isDead == false)
            flappyManager.AddScore(1);
    }
}
