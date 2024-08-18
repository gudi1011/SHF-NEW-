using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueUI;  // ��ȭâ UI
    public TypingEffect typingEffect;  // Ÿ���� ȿ���� ���� ��ũ��Ʈ
    public string[] dialogueLines;  // ��ȭ ������ ������ �迭
    private int currentLineIndex = 0;  // ���� ��ȭ ������ �ε���

    private bool isDialogueActive = false;  // ��ȭâ�� Ȱ��ȭ�� �������� üũ
    private bool hasDialogueEnded = false;  // ��ȭ�� �������� üũ

    private void Start()
    {
        dialogueUI.SetActive(false);  // ó���� ��ȭâ�� ��Ȱ��ȭ
    }

    public void StartDialogue(string[] lines)
    {
        if (hasDialogueEnded) return; // ��ȭ�� ���� ���¿����� ��ȭ �������� ����

        dialogueLines = lines;
        currentLineIndex = 0;
        isDialogueActive = true;
        hasDialogueEnded = false;
        dialogueUI.SetActive(true);
        DisplayNextLine();
    }

    public void OnDialogueClick()
    {
        if (!isDialogueActive) return;

        currentLineIndex++;
        if (currentLineIndex < dialogueLines.Length)
        {
            DisplayNextLine();
        }
        else
        {
            EndDialogue();
        }
    }

    private void DisplayNextLine()
    {
        typingEffect.StartTyping(dialogueLines[currentLineIndex]);
    }

    private void EndDialogue()
    {
        isDialogueActive = false;
        hasDialogueEnded = true;
        dialogueUI.SetActive(false);
    }

    public bool IsDialogueActive()
    {
        return isDialogueActive;
    }
}
