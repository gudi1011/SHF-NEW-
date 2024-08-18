using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrangeObjectsInCircle : MonoBehaviour
{
    public GameObject[] objectsToArrange; // 배치할 오브젝트들
    public float radius = 3f; // 원의 반지름

    private void Start()
    {
        ArrangeInCircle();
    }

    private void ArrangeInCircle()
    {
        if (objectsToArrange.Length == 0)
            return;

        float angleStep = 360f / objectsToArrange.Length; // 각 오브젝트 간의 각도

        for (int i = 0; i < objectsToArrange.Length; i++)
        {
            float angle = angleStep * i;
            Vector3 newPosition = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad) * radius, 0, Mathf.Sin(angle * Mathf.Deg2Rad) * radius);
            objectsToArrange[i].transform.localPosition = newPosition; // 부모 오브젝트를 기준으로 배치
            objectsToArrange[i].transform.localRotation = Quaternion.identity; // 회전값 초기화
        }
    }
}
