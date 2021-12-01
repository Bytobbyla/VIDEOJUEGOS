using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] int puntosDeDano;
    private Rigidbody2D MyRb;
    public float speed;
    Animator myAnimator;
    [SerializeField] AudioClip sfx_explotion;
    private CircleCollider2D myCollider;
    // Start is called before the first frame update
    void Start()
    {
        MyRb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myCollider = GetComponent<CircleCollider2D>();
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
        if (etiqueta != "Player")
        {
            Destroy(gameObject, 0.3f);
            MyRb.velocity = transform.right * 0;
            myAnimator.SetTrigger("explota");
            
            AudioSource.PlayClipAtPoint(sfx_explotion, Camera.main.transform.position);
            
            
        }

    }
    public int darPuntosDeDano()
    {
        return puntosDeDano;
    }

}
