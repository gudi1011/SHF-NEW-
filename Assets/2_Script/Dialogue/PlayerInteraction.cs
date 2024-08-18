using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject test;
    public GameObject test2;
    private bool isWork = false;

    public DialogueManager dialogueManager;
    public float waitTimeBeforeDialogue = 2f; // ��ȭâ�� ��Ÿ���� �� ��� �ð�
    public string[] dialogueLines; // ��ȭ ����

    private bool isPlayerInRange = false;
    private float timer = 0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            isPlayerInRange = true;
            timer = 0f; // ��� �ð� Ÿ�̸� �ʱ�ȭ
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            isPlayerInRange = false;
            timer = 0f; // ��� �ð� Ÿ�̸� �ʱ�ȭ
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