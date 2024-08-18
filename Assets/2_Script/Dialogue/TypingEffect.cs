using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypingEffect : MonoBehaviour
{
    public Text dialogueText;  // ��ȭ ������ ǥ���� UI Text
    public float typingSpeed = 0.05f;  // ���ڰ� Ÿ���εǴ� �ӵ�

    private string currentLine;

    public void StartTyping(string line)
    {
        currentLine = line;
        dialogueText.text = "";
        StopAllCoroutines();  // ���� Ÿ���� �ڷ�ƾ�� ������ ����
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
