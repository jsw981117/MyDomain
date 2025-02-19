using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgLooper : MonoBehaviour
{
    public int numBgCount = 3;
    public int obstacleCount = 0;
    public Vector3 obstacleLastPosition = Vector3.zero;

    void Start()
    {
        Obstacle[] obstacles = GameObject.FindObjectsOfType<Obstacle>();
        obstacleLastPosition = obstacles[0].transform.position;

        for (int i = 0; i < obstacles.Length; i++)
        {
            obstacleLastPosition = obstacles[i].SetRandomPlace(obstacleLastPosition, obstacleCount);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"Triggerd: {collision.name}");

        if (collision.CompareTag("BackGround")) // 배경을 이동시킴
        {
            float widthOfBgObject = ((BoxCollider2D)collision).size.x;
            Vector3 pos = collision.transform.position;

            pos.x += widthOfBgObject * numBgCount;
            collision.transform.position = pos;
            return;
        }

        Obstacle obstacle = collision.GetComponent<Obstacle>();
        if (obstacle) // 장애물을 이동시킴
        {
            obstacleLastPosition = obstacle.SetRandomPlace(obstacleLastPosition, obstacleCount);
        }
    }
}
