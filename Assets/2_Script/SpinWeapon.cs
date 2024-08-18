using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinWeapon : MonoBehaviour
{
    public Transform playerTrans;
    public GameObject[] objectsToManage; // 회전할 오브젝트들
    public int activeCount = 3; // 활성화할 오브젝트 개수
    public float spinSpeed = 30f; // 회전 속도
    public float activationDelay = 1f; // 오브젝트가 활성화되는 간격

    private void Start()
    {
        // 오브젝트 초기화
        StartCoroutine(ManageObjects());
    }

    private void Update()
    {
        // 빈 게임 오브젝트를 중심으로 회전
        transform.Rotate(Vector3.up * spinSpeed * Time.deltaTime, Space.World);
        transform.position = playerTrans.position;
    }

    private IEnumerator ManageObjects()
    {
        while (true)
        {
            // 모든 오브젝트 비활성화
            foreach (GameObject obj in objectsToManage)
            {
                obj.SetActive(false);
            }

            // 지정된 개수만큼 오브젝트 활성화
            for (int i = 0; i < activeCount; i++)
            {
                if (i < objectsToManage.Length)
                {
                    objectsToManage[i].SetActive(true);
                }
            }

            // 다음 활성화 사이의 지연 시간
            yield return new WaitForSeconds(activationDelay);
        }
    }
}
