using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coleccionable : MonoBehaviour
{
    [SerializeField] AudioClip sfx_recoleccion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject objeto = collision.gameObject;
        string etiqueta = objeto.tag;
        if (etiqueta == "Player")
        {
            AudioSource.PlayClipAtPoint(sfx_recoleccion, Camera.main.transform.position);
            Destroy(this.gameObject);
        }

    }
}
