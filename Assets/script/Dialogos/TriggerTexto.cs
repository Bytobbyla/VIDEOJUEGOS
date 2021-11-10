using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTexto : MonoBehaviour

{
    public Dialogo dialogo;
    
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
        
        
        if (Input.GetKey(KeyCode.E) && dialogue==true && In==false)
        {
            FindObjectOfType<DialogueManager>().StartDialogo(dialogo);
            activarDialogo.SetActive(true);
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
