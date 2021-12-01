using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptDisparoBoss : MonoBehaviour
{
    [SerializeField] int puntosDanoDisparo;
    
    private Rigidbody2D MyRb;
    public Animator ani;
    public float speed;
    private Transform player;
    private Vector2 target;

    public personaje personaje;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
        MyRb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if(transform.position.x==target.x && transform.position.y == target.y)
        {
            StartCoroutine(Destruir());
            
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject objeto = collision.gameObject;
        string etiqueta = objeto.tag;
        if (etiqueta == "Player")
        {
            
            

            int puntos = puntosDanoDisparo;
            personaje.PuntosSalud = personaje.PuntosSalud - puntos;
            darPuntosDeDanoDisparo();
            DestruirDisparo();
        }
    }
    void DestruirDisparo()
    {
        Destroy(gameObject);
    }
    public int darPuntosDeDanoDisparo()
    {
        return puntosDanoDisparo;

    }
    private IEnumerator Destruir()
    {
        ani.SetTrigger("Destruir");
        yield return new WaitForSeconds(0.25f);
        DestruirDisparo();
    }
}
