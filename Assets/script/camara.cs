using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camara : MonoBehaviour
{
    public GameObject objetivo;
    private Vector3 posicion;

    // Start is called before the first frame update
    void Start()
    {
        //LINEA PARA GUARDAR POSICION DEL PERSONAJE
       posicion = transform.position - objetivo.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //SIGUE AL PERSONAJE
        transform.position = objetivo.transform.position + posicion;
    }
}
