using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinWeapon : MonoBehaviour
{
    public Transform playerTrans;
    public GameObject[] objectsToManage; // ȸ���� ������Ʈ��
    public int activeCount = 3; // Ȱ��ȭ�� ������Ʈ ����
    public float spinSpeed = 30f; // ȸ�� �ӵ�
    public float activationDelay = 1f; // ������Ʈ�� Ȱ��ȭ�Ǵ� ����

    private void Start()
    {
        // ������Ʈ �ʱ�ȭ
        StartCoroutine(ManageObjects());
    }

    private void Update()
    {
        // �� ���� ������Ʈ�� �߽����� ȸ��
        transform.Rotate(Vector3.up * spinSpeed * Time.deltaTime, Space.World);
        transform.position = playerTrans.position;
    }

    private IEnumerator ManageObjects()
    {
        while (true)
        {
            // ��� ������Ʈ ��Ȱ��ȭ
            foreach (GameObject obj in objectsToManage)
            {
                obj.SetActive(false);
            }

            // ������ ������ŭ ������Ʈ Ȱ��ȭ
            for (int i = 0; i < activeCount; i++)
            {
                if (i < objectsToManage.Length)
                {
                    objectsToManage[i].SetActive(true);
                }
            }

            // ���� Ȱ��ȭ ������ ���� �ð�
            yield return new WaitForSeconds(activationDelay);
        }
    }
}
