using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEnemigo : MonoBehaviour
{
    [SerializeField] int puntosDano;
    public bool dano;
    public personaje personaje;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            print("dano");
            darPuntosDeDano();

            int puntos = puntosDano;
            personaje.PuntosSalud = personaje.PuntosSalud - puntos;


        }

    }
    public int darPuntosDeDano()
    {
        return puntosDano;
        
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
