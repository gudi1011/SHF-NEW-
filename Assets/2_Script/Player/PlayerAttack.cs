using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform playerTrans;
    public int attackDamage = 10;
    public float knockbackForce = 5f; // 넉백 힘

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
                // 적의 넉백 처리를 위해 KnockbackCoroutine을 호출합니다.
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
        // 넉백 적용
        Rigidbody enemyRb = enemy.GetComponent<Rigidbody>();
        if (enemyRb != null)
        {
            Vector3 direction = (enemy.transform.position - playerTrans.position).normalized;
            enemyRb.AddForce(direction * knockbackForce, ForceMode.Impulse);
        }

        yield return null; // 또는 필요에 따라 적절한 대기 시간 추가
    }
}
