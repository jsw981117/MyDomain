using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialoguePanel; // ��ȭâ �г�
    public TextMeshProUGUI dialogueText; // ��ȭ ����

    private Queue<string> sentences; // ��ȭ ���� ť
    private bool isTyping = false; // Ÿ���� ȿ�� ���� ������ Ȯ��
    string currentSentence;

    void Start()
    {
        sentences = new Queue<string>();
        dialoguePanel.SetActive(false); // ���� �� ��ȭâ �����
    }
    void Update()
    {
        // ���콺 Ŭ�� or ȭ�� ��ġ �� ���� ��� ����
        if (dialoguePanel.activeSelf && Input.GetMouseButtonDown(0))
        {
            if (isTyping)
            {
                StopAllCoroutines();
                dialogueText.text = currentSentence; // ���� ���� ��� ���
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
        dialoguePanel.SetActive(true); // ��ȭâ ǥ��
        sentences.Clear(); // ���� ��ȭ �ʱ�ȭ

        foreach (string sentence in dialogueLines)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence(); // ù ��° ��� ǥ��
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
            yield return new WaitForSeconds(0.05f); // �� ���ھ� ���
        }
        isTyping = false;
    }

    void EndDialogue()
    {
        dialoguePanel.SetActive(false); // ��ȭ ���� �� â �����
    }
}
