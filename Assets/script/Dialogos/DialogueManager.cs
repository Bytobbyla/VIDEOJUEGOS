using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueManager : MonoBehaviour
{
    public Image characterImage;
    public Text nameText;
    public Text dialogueText;
    public Animator animator;

    public Queue<string> sentences;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Z))
        {
            DisplayNextSentence();

        }

    }

    public void StartDialogo(Dialogo dialogo)
    {
        (GameObject.Find("personaje").GetComponent<personaje>()).enDialogo();
        animator.SetBool("IsOpen", true);
        nameText.text = dialogo.name;
        
        sentences.Clear();
        foreach (string sentence in dialogo.sentences)
        {
            sentences.Enqueue(sentence);

        }
       
            DisplayNextSentence();
        
    }

    public void DisplayNextSentence()
    {
     
            if (sentences.Count == 0)
            {
                EndDialogo();
                return;
            }

            string sentence = sentences.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));
        
    }

    void EndDialogo()
    {
        Debug.Log("fin de la conversacion");
        animator.SetBool("IsOpen", false);
        (GameObject.Find("personaje").GetComponent<personaje>()).fueraDialogo();

    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {

            dialogueText.text += letter;
            yield return null;
        }
    }
   
}
