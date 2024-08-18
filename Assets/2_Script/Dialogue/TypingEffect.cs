using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypingEffect : MonoBehaviour
{
    public Text dialogueText;  // 대화 내용을 표시할 UI Text
    public float typingSpeed = 0.05f;  // 글자가 타이핑되는 속도

    private string currentLine;

    public void StartTyping(string line)
    {
        currentLine = line;
        dialogueText.text = "";
        StopAllCoroutines();  // 이전 타이핑 코루틴이 있으면 중지
        StartCoroutine(TypeLine());
    }

    private IEnumerator TypeLine()
    {
        foreach (char letter in currentLine.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
