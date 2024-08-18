using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform playerTrans;
    public int attackDamage = 10;
    public float knockbackForce = 5f; // �˹� ��

    private bool hasCollided = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && hasCollided == false)
        {
            hasCollided = true;

            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(10);
                // ���� �˹� ó���� ���� KnockbackCoroutine�� ȣ���մϴ�.
                StartCoroutine(KnockbackCoroutine(enemy));
            }
        }

        StartCoroutine(ResetCollisionFlag());
    }

    private IEnumerator ResetCollisionFlag()
    {
        yield return new WaitForSeconds(0.05f);
        hasCollided = false;
    }

    private IEnumerator KnockbackCoroutine(Enemy enemy)
    {
        // �˹� ����
        Rigidbody enemyRb = enemy.GetComponent<Rigidbody>();
        if (enemyRb != null)
        {
            Vector3 direction = (enemy.transform.position - playerTrans.position).normalized;
            enemyRb.AddForce(direction * knockbackForce, ForceMode.Impulse);
        }

        yield return null; // �Ǵ� �ʿ信 ���� ������ ��� �ð� �߰�
    }
}
