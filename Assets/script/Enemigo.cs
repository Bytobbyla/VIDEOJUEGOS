using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int PuntosSaludEnemigo;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Ataque"))
        {

            int puntos = collision.gameObject.GetComponent<Bullet>().darPuntosDeDano();
            PuntosSaludEnemigo = PuntosSaludEnemigo - puntos;

            if (PuntosSaludEnemigo < 1)
            {

                Destroy(this.gameObject);
            }


        }
    }
}
