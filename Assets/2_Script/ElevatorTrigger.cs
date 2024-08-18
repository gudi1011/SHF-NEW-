using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElevatorTrigger : MonoBehaviour
{
    public Transform elevatorPosition;
    public float waitTimeBeforeEnter = 2f;
    public float waitTimeInElevator = 3f;
    public string nextSceneName;
    public ScreenFader screenFader; // 페이드 스크립트
    public GameObject panel;

    private bool isPlayerInTrigger = false;
    private bool isMovingToElevator = false;
    private float timer = 0f;
    private GameObject player;
    private Rigidbody playerRb;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
            player = other.gameObject;
            playerRb = player.GetComponent<Rigidbody>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
            timer = 0f;
        }
    }

    private void Update()
    {
        if (isPlayerInTrigger && !isMovingToElevator)
        {
            timer += Time.deltaTime;
            if (timer >= waitTimeBeforeEnter)
            {
                StartCoroutine(MoveToElevator());
            }
        }
    }

    private IEnumerator MoveToElevator()
    {
        isMovingToElevator = true;

        // 화면 페이드 인
        yield return StartCoroutine(screenFader.FadeIn());

        playerRb.isKinematic = true;
        player.transform.position = elevatorPosition.position;
        player.transform.rotation = elevatorPosition.rotation;

        yield return new WaitForSeconds(0.5f);
        playerRb.isKinematic = false;

        // 페이드 아웃
        yield return StartCoroutine(screenFader.FadeOut());

        yield return new WaitForSeconds(1f);
        panel.SetActive(true);
    }

    public void OnClickFloor()
    {
        StartCoroutine(SceneMove());
    }

    private IEnumerator SceneMove()
    {
        yield return new WaitForSeconds(waitTimeInElevator);

        // 씬 이동
        SceneManager.LoadScene(nextSceneName);
    }
}
