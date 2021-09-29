using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class personaje : MonoBehaviour
{
    
    public float speed;
    [SerializeField] float fireRate1;
    public float altura;
    public float tiempoSalto;
    private Rigidbody2D MyRb;
    float maxX, minX,nextFire;
    
    
    public Transform Cheker;
    public Transform FirePoint;
    public GameObject Bullet;
    public float RadioDeCheker;
    public bool TocaElPiso;
    public LayerMask Piso;
    // Start is called before the first frame update
    void Start()
    {
        //CÓDIGO PARA QUE LA CAMARA SIGA AL PERSONAJE
        MyRb = GetComponent<Rigidbody2D>();
        Vector2 esquinaInfDer = Camera.main.ViewportToWorldPoint(new Vector2(1, 0));
        Vector2 esquinaInfIzq = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        maxX = esquinaInfDer.x;
        minX = esquinaInfIzq.x;
    }
    

    // Update is called once per frame
    void Update()
    {
        float movH = Input.GetAxis("Horizontal");
        float movV = Input.GetAxis("Vertical");
        
       
        //PERSONAJE MIRANDO A LA DERECHA
        if (movH > 0.1f)
        {
            Vector2 movimiento = new Vector2(movH * Time.deltaTime * speed, 0);
            transform.eulerAngles = new Vector3(0, 0, 0);
            transform.Translate(movimiento);
        }

        //PERSONAJE MIRANDO A LA IZQUIERDA
       if (movH < -0.1f)
        {
            Vector2 movimiento = new Vector2(-movH * Time.deltaTime * speed, 0);
            transform.eulerAngles = new Vector3(0, 180, 0);
            transform.Translate(movimiento);
        }
       
       //PERSONAJE QUIETO
        if (movH == 0)
        {
            Vector2 movimiento = new Vector2(0f, 0f);
            transform.Translate(movimiento);
        }
        
        
        //COLLIDER PARA PODER SALTAR AL TOCAR PISO
        if (Input.GetKeyDown(KeyCode.Space) && TocaElPiso == true)
        {
            MyRb.velocity = new Vector2(MyRb.velocity.x, altura);
           
        }
        TocaElPiso = Physics2D.OverlapCircle(Cheker.position,RadioDeCheker,Piso);
        Disparo();
    }
    public void Disparo()
    {
        //DISPARAR RAFAGA CADA 1 SEGUNDO 
            if (Input.GetKeyDown(KeyCode.E) && Time.time >= nextFire)
            {
                Instantiate(Bullet, FirePoint.position, FirePoint.rotation);
                nextFire = Time.time + fireRate1;
            }     
    }
    void OnCollisionEnter2D (Collision2D collision)
    {
       
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        int previousSecene = SceneManager.GetActiveScene().buildIndex - 1;

        if (collision.gameObject.CompareTag("Entrada"))
        {
            SceneManager.LoadScene(nextScene);
        }
        if (collision.gameObject.CompareTag("Salida"))
        {
            SceneManager.LoadScene(previousSecene);
        }
    }
}
