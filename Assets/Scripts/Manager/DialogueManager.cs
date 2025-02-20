using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialoguePanel; // 대화창 패널
    public TextMeshProUGUI dialogueText; // 대화 내용

    private Queue<string> sentences; // 대화 저장 큐
    private bool isTyping = false; // 타이핑 효과 진행 중인지 확인
    string currentSentence;

    void Start()
    {
        sentences = new Queue<string>();
        dialoguePanel.SetActive(false); // 시작 시 대화창 숨기기
    }
    void Update()
    {
        // 마우스 클릭 or 화면 터치 시 다음 대사 진행
        if (dialoguePanel.activeSelf && Input.GetMouseButtonDown(0))
        {
            if (isTyping)
            {
                StopAllCoroutines();
                dialogueText.text = currentSentence; // 현재 문장 즉시 출력
                isTyping = false;
            }
            else
            {
                DisplayNextSentence();
            }
        }
    }

    public void StartDialogue(List<string> dialogueLines)
    {
        dialoguePanel.SetActive(true); // 대화창 표시
        sentences.Clear(); // 기존 대화 초기화

        foreach (string sentence in dialogueLines)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence(); // 첫 번째 대사 표시
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        
        string sentence = sentences.Dequeue();
        currentSentence = sentence;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        isTyping = true;
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.05f); // 한 글자씩 출력
        }
        isTyping = false;
    }

    void EndDialogue()
    {
        dialoguePanel.SetActive(false); // 대화 종료 시 창 숨기기
    }
}
