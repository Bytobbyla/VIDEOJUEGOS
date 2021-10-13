using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTexto : MonoBehaviour

{
    public Dialogo dialogo;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject objeto = collision.gameObject;
        string etiqueta = objeto.tag;
        if (etiqueta == "Player")
        {
          FindObjectOfType<DialogueManager>().StartDialogo(dialogo);   
        }

    }
  
    
}
