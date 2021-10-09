using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] int puntosDeDano;
    private Rigidbody2D MyRb;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        MyRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //LINEA PARA QUE EL DISPARO CAMBIE DE POSICIÓN CUANDO EL PERSONAJE LO HAGA
        MyRb.velocity = transform.right * speed; ;
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject objeto = collision.gameObject;
        string etiqueta = objeto.tag;
        if(etiqueta != "Player")
        {
            Destroy(this.gameObject);
        }
        
    }
    public int darPuntosDeDano()
    {
        return puntosDeDano;
    }

}
