using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject test;
    public GameObject test2;
    private bool isWork = false;

    public DialogueManager dialogueManager;
    public float waitTimeBeforeDialogue = 2f; // 대화창이 나타나기 전 대기 시간
    public string[] dialogueLines; // 대화 내용

    private bool isPlayerInRange = false;
    private float timer = 0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            isPlayerInRange = true;
            timer = 0f; // 대기 시간 타이머 초기화
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            isPlayerInRange = false;
            timer = 0f; // 대기 시간 타이머 초기화
        }
    }

    private void Update()
    {
        if (isPlayerInRange && !dialogueManager.IsDialogueActive() && !isWork)
        {
            timer += Time.deltaTime;
            if (timer >= waitTimeBeforeDialogue)
            {
                //dialogueManager.StartDialogue(dialogueLines);
                test.SetActive(true);
                test2.SetActive(true);
                isWork = true;
            }
        }
    }
}