using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPC : MonoBehaviour
{
    public delegate void DialogueCompleteEventHandler();
    public event DialogueCompleteEventHandler OnDialogueComplete;

    public GameObject dialoguePanel;
    public TMP_Text dialogueText;
    public string[] dialogue;
    private int index;

    public GameObject contButton;
    public float wordSpeed;
    public bool PlayerIsClose;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && PlayerIsClose)
        {
            if (dialoguePanel.activeSelf)
            {
                zeroText();
            }
            else
            {
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }      
    }

    private void Start()
    {
        // Подписываемся на событие OnDialogueComplete
        OnDialogueComplete += ShowContinueButton;
    }

    private void OnDestroy()
    {
        // Отменяем подписку на событие при уничтожении объекта
        OnDialogueComplete -= ShowContinueButton;
    }

    private void ShowContinueButton()
    {
        contButton.SetActive(true);
    }

    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        foreach(char letter in dialogue[index].ToCharArray()) 
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }

        OnDialogueComplete?.Invoke();
    }

    public void NextLine()
    {
        contButton.SetActive(false);

        if (index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            zeroText();
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerIsClose = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerIsClose = false;
            zeroText();
        }
    }
}
