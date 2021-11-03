using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTexto : MonoBehaviour

{
    public Dialogo dialogo;
    [SerializeField] private GameObject activarDialogo;
    

    void OnTriggerEnter2D(Collider2D other)
    {

        FindObjectOfType<DialogueManager>().StartDialogo(dialogo);
        activarDialogo.SetActive(true); 

    }
    


}
