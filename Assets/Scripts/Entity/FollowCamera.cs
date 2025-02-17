using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    float offsetX, offsetY;
    public float smoothSpeed = 0.75f;
    public float followThreshold = 2.0f; // Ÿ�ٰ� ī�޶��� �Ÿ� �Ӱ谪

    private void Start()
    {
        if (target == null) return;

        offsetX = transform.position.x - target.position.x;
        offsetY = transform.position.y - target.position.y;
    }


    private void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = new Vector3(target.position.x + offsetX, target.position.y + offsetY, transform.position.z);
        float distance = Vector3.Distance(transform.position, desiredPosition);

        if (distance > followThreshold)
        {
            float dynamicSmoothSpeed = smoothSpeed * (distance / followThreshold); // �Ÿ� ��� �ӵ� ����
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, dynamicSmoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        }
        else
        {
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        }
    }
}
