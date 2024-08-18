using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrangeObjectsInCircle : MonoBehaviour
{
    public GameObject[] objectsToArrange; // ��ġ�� ������Ʈ��
    public float radius = 3f; // ���� ������

    private void Start()
    {
        ArrangeInCircle();
    }

    private void ArrangeInCircle()
    {
        if (objectsToArrange.Length == 0)
            return;

        float angleStep = 360f / objectsToArrange.Length; // �� ������Ʈ ���� ����

        for (int i = 0; i < objectsToArrange.Length; i++)
        {
            float angle = angleStep * i;
            Vector3 newPosition = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad) * radius, 0, Mathf.Sin(angle * Mathf.Deg2Rad) * radius);
            objectsToArrange[i].transform.localPosition = newPosition; // �θ� ������Ʈ�� �������� ��ġ
            objectsToArrange[i].transform.localRotation = Quaternion.identity; // ȸ���� �ʱ�ȭ
        }
    }
}
