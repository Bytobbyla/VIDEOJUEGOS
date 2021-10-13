using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    public Queue<string> sentences;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();

    }

    public void StartDialogo (Dialogo dialogo) 
    {
        nameText.text = dialogueText.name;

        sentences.Clear();
        foreach (string sentence in dialogo.sentences) 
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence ()
    {
        if (sentences.Count == 0) 
        {
            EndDialogo();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }
    void EndDialogo() 
    {
        Debug.Log("fin de la conversacion");
    
    } 



}
