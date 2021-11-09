using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    [SerializeField] public Image dialogueImage;
    public Animator animator;

    
    public Queue<Sprite> characterImage;
    public Queue<string> characterName;
    public Queue<string> sentences;
    // Start is called before the first frame update
    void Start()
    {
        
        sentences = new Queue<string>();
        characterName = new Queue<string>();
        characterImage = new Queue<Sprite>();
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

        characterImage.Clear();
        sentences.Clear();
        characterName.Clear();
        foreach (string sentence in dialogo.sentences)
        {
            sentences.Enqueue(sentence);

        }
        foreach (string Names in dialogo.characterName)
        {
           characterName.Enqueue(Names);

        }
        foreach (Sprite Imagenes in dialogo.characterImage)
        {
            characterImage.Enqueue(Imagenes);
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
        string Names = characterName.Dequeue();
            string sentence = sentences.Dequeue();
        Sprite Imagenes = characterImage.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));
        StartCoroutine(TypeNames(Names));
        StartCoroutine(ChangeImage(Imagenes));

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
    IEnumerator TypeNames(string Names)
    {

        nameText.text = "";
        foreach (char letter in Names.ToCharArray())
        {

            nameText.text += letter;
            yield return null;

        }
    }
    IEnumerator ChangeImage(Sprite Imagenes)
    {
        dialogueImage.sprite = Imagenes;
        yield return null;
        dialogueImage.preserveAspect = true;

    }







}
