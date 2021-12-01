using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTexto : MonoBehaviour

{
    public Dialogo dialogo;
    [SerializeField] AudioClip sfx_int;
    [SerializeField] private GameObject activarDialogo;
    public bool dialogue;
    private bool In;
    private void Start()
    {
        dialogue = false;
        In = false;
    }

    private void Update()
    {
        
        
        if (Input.GetKey(KeyCode.Q) && dialogue==true && In==false)
        {
            AudioSource.PlayClipAtPoint(sfx_int, Camera.main.transform.position);
            FindObjectOfType<DialogueManager>().StartDialogo(dialogo);
            activarDialogo.SetActive(true);
            enDialogo();
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            dialogue = true;
            FindObjectOfType<personaje>().rangoDialogo();
        }


    }
    void OnTriggerExit2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            dialogue = false;
            fueraDialogo();
            FindObjectOfType<personaje>().fueraRangoDialogo();
        }


    }
    public void enDialogo()
    {
        In = true;
    }
    public void fueraDialogo()
    {
        In = false;
    }




}
