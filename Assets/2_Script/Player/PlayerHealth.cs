using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int hp = 100;
    public float invincibilityTime = 2f;
    public float knockbackForce = 5f;
    private bool isInvincible = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyAttack"))
        {
            // ���� ���ݸ� ó��
            if (!isInvincible)
            {
                TakeDamage(10);
                Knockback(other.transform);
                StartCoroutine(InvincibilityCoroutine());
            }
        }
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void Knockback(Transform attacker)
    {
        Rigidbody playerRb = GetComponent<Rigidbody>();
        if (playerRb != null)
        {
            // �������� ������ �ݴ� �������� �˹�
            Vector3 direction = (transform.position - attacker.position).normalized;
            playerRb.AddForce(direction * knockbackForce, ForceMode.Impulse);
        }
    }

    private IEnumerator InvincibilityCoroutine()
    {
        isInvincible = true;
        yield return new WaitForSeconds(invincibilityTime);
        isInvincible = false;
    }
}
