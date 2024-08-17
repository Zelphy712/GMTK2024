using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI NPCNameText;

    [SerializeField] private TextMeshProUGUI NPCDialogueText;
    [SerializeField] private float typeSpeed;

    private Queue<string> paragraphs = new Queue<string>();

    private bool conversationEnded;
    private bool isTyping;
    private string p;

    private Coroutine typeDialogueCoroutine;
    private const float MAX_TYPE_TIME = 0.1f;


    public void DisplayNextParagraph(DialogueText dialogueText){
        if(paragraphs.Count == 0){
            if(!conversationEnded){
                StartConversation(dialogueText);
            }else if (conversationEnded && !isTyping){
                EndConversation();
                return;
            }
        }

        //p = paragraphs.Dequeue();
        //NPCDialogueText.text = p;
        
        if( !isTyping){
            p = paragraphs.Dequeue();
            typeDialogueCoroutine = StartCoroutine(TypeDialogueText(p));
        }else{
            FinishParagraphEarly();
        }

        if(paragraphs.Count == 0){
            conversationEnded = true;
        }
    }
    private void StartConversation(DialogueText dialogueText){
        //activate gameObject
        if(!gameObject.activeSelf){
            gameObject.SetActive(true);
        }
        //update name
        NPCNameText.text = dialogueText.speakerName;
        //add dialogue text into queue
        for (int i = 0; i < dialogueText.paragraphs.Length; i++)
        {
            paragraphs.Enqueue(dialogueText.paragraphs[i]);
        }
    }

    private void EndConversation(){
        //clear queue
        paragraphs.Clear();
        conversationEnded = false;
        if(gameObject.activeSelf){
            gameObject.SetActive(false);
        }
    }

    private IEnumerator TypeDialogueText(string p)
    {
        isTyping = true;

        int maxVisibleChars = 0;

        NPCDialogueText.text = p;
        NPCDialogueText.maxVisibleCharacters = maxVisibleChars;

        foreach (char c in p.ToCharArray())
        {

            maxVisibleChars++;
            NPCDialogueText.maxVisibleCharacters = maxVisibleChars;

            yield return new WaitForSeconds(MAX_TYPE_TIME / typeSpeed);
        }

        isTyping = false;
    }

    private void FinishParagraphEarly(){
        //stop coroutine
        StopCoroutine(typeDialogueCoroutine);

        //finish displaying text
        NPCDialogueText.maxVisibleCharacters = 99999;//probably more than necessary, which is what i want here
        NPCDialogueText.text = p;

        //update isTyping
        isTyping = false;
    }
}
