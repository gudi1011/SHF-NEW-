using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public int hp = 30;
    public float moveSpeed = 3f;
    public float attackDistance = 1.5f;
    public float attackRate = 1f;
    public GameObject idCardPrefab;
    public float knockbackForce = 5f; // 넉백 힘
    public float knockbackDuration = 0.5f; // 넉백 지속 시간
    private Transform player;
    private bool isKnockedBack = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(AttackRoutine());
    }

    private void Update()
    {
        MoveTowardsPlayer();
    }

    private void MoveTowardsPlayer()
    {
        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
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
        DropIdCard();
        Destroy(gameObject);
    }

    private void DropIdCard()
    {
        if (idCardPrefab != null)
        {
            Instantiate(idCardPrefab, transform.position, Quaternion.identity);
        }
    }

    private IEnumerator AttackRoutine()
    {
        while (true)
        {
            if (player != null && Vector3.Distance(transform.position, player.position) <= attackDistance)
            {
                if (!isKnockedBack)
                {
                    // 공격 애니메이션
                }
                yield return new WaitForSeconds(attackRate);
            }
            yield return null;
        }
    }

    
}
