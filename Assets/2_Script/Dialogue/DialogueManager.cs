using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueUI;  // 대화창 UI
    public TypingEffect typingEffect;  // 타이핑 효과를 위한 스크립트
    public string[] dialogueLines;  // 대화 내용을 저장할 배열
    private int currentLineIndex = 0;  // 현재 대화 라인의 인덱스

    private bool isDialogueActive = false;  // 대화창이 활성화된 상태인지 체크
    private bool hasDialogueEnded = false;  // 대화가 끝났는지 체크

    private void Start()
    {
        dialogueUI.SetActive(false);  // 처음엔 대화창을 비활성화
    }

    public void StartDialogue(string[] lines)
    {
        if (hasDialogueEnded) return; // 대화가 끝난 상태에서는 대화 시작하지 않음

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
