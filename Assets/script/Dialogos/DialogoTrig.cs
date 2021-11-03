using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogoTrig : MonoBehaviour
{
    public Dialogo dialogo;



    public void TriggerDialogue() 
    {
        FindObjectOfType<DialogueManager>().StartDialogo(dialogo);
        
    }


}
