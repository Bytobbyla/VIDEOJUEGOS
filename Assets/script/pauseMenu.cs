using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour
{
    public GameObject objetivo;
    private Vector3 posicion;

    // Start is called before the first frame update
    void Start()
    {
        posicion = transform.position - objetivo.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = objetivo.transform.position + posicion;
    }
}
