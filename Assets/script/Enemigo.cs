using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int PuntosSaludEnemigo;
    public GameObject ObjetoAmover;
    public Transform StartPoint;
    public Transform EndPoint;
    

    public float speed;
  
    private Vector3 MoverHacia;

    //variable para guardar jugador
    GameObject player;

    //variable para guardar la posicion inicial
    Vector3 initialPosition, target;

    Animator anim;
    Rigidbody2D rb2d;
    void Start()
    {
       
        MoverHacia = EndPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
       
        
        
        ObjetoAmover.transform.position = Vector3.MoveTowards(ObjetoAmover.transform.position, MoverHacia, speed * Time.deltaTime);
        
        
        if(ObjetoAmover.transform.position == EndPoint.position)
        {
            MoverHacia = StartPoint.position;
        }
        if (ObjetoAmover.transform.position == StartPoint.position)
        {
            MoverHacia = EndPoint.position;
        }

    }
   
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Ataque"))
        {

           
            PuntosSaludEnemigo --;
            int puntos = collision.gameObject.GetComponent<Bullet>().darPuntosDeDano();
            if (PuntosSaludEnemigo < 1)
            {

                Destroy(this.gameObject);
            }


        }
    }
}
