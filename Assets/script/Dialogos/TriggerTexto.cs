using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTexto : MonoBehaviour

{
    public Dialogo dialogo;
    
    

    void OnTriggerEnter2D(Collider2D other)
    {

         FindObjectOfType<DialogueManager>().StartDialogo(dialogo);
        activarDialogo.SetActive(true);     

    }
    public bool DialogueActive()
    {
        return activarDialogo.activeInHierarchy;
    }


}
