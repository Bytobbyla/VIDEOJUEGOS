using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class personaje : MonoBehaviour
{
    Animator myAnimator;
    public float speed;
    [SerializeField] float fireRate1;
    [SerializeField] public float PuntosSalud;
    public float altura;
    public float tiempoSalto;
    private Rigidbody2D MyRb;
    float maxX, minX, nextFire;
    public bool InDialogue;
    private bool rangodialogo;
    float vidaMaxima =10f;

    public Image barraDeVida;
    public Transform Cheker;
    public Transform FirePoint;
    public GameObject Bullet;
    public float RadioDeCheker;
    public bool TocaElPiso;
    public LayerMask Piso;
    public HitEnemigo hitEnemigo;
    
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        InDialogue = false;
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
        
        barraDeVida.fillAmount = PuntosSalud / vidaMaxima;
        if (InDialogue == false)
        {
            Dano();

            float movH = Input.GetAxis("Horizontal");
            float movV = Input.GetAxis("Vertical");


            //PERSONAJE MIRANDO A LA DERECHA
            if (movH > 0.1f)
            {
                Vector2 movimiento = new Vector2(movH * Time.deltaTime * speed, 0);
                transform.eulerAngles = new Vector3(0, 0, 0);
                transform.Translate(movimiento);
                myAnimator.SetBool("IsRunning", true);
            }

            //PERSONAJE MIRANDO A LA IZQUIERDA
            if (movH < -0.1f)
            {
                Vector2 movimiento = new Vector2(-movH * Time.deltaTime * speed, 0);
                transform.eulerAngles = new Vector3(0, 180, 0);
                transform.Translate(movimiento);
                myAnimator.SetBool("IsRunning", true);
            }

            //PERSONAJE QUIETO
            if (movH == 0)
            {
                Vector2 movimiento = new Vector2(0f, 0f);
                transform.Translate(movimiento);
                myAnimator.SetBool("IsRunning", false);
            }


            //COLLIDER PARA PODER SALTAR AL TOCAR PISO
            if (Input.GetKeyDown(KeyCode.Space) && TocaElPiso == true)
            {
                MyRb.velocity = new Vector2(MyRb.velocity.x, altura);
                myAnimator.SetTrigger("salto");
                myAnimator.SetBool("itsFalling", false);

            }
            if (TocaElPiso == true)
            {
                myAnimator.SetBool("itsFalling", false);
            }
           
            TocaElPiso = Physics2D.OverlapCircle(Cheker.position, RadioDeCheker, Piso);
            Disparo();
            caer();
        }
        
    }
    
    public void caer()
    {
        if (MyRb.velocity.y < 0 && !myAnimator.GetBool("takeof"))
        {
            myAnimator.SetBool("itsFalling", true);

        }
    }
    public void Disparo()
    {
        //DISPARAR RAFAGA CADA 1 SEGUNDO 
        if (Input.GetKeyDown(KeyCode.E) && Time.time >= nextFire && rangodialogo==false)
        {
            Instantiate(Bullet, FirePoint.position, FirePoint.rotation);
            nextFire = Time.time + fireRate1;
        }
    }
    //(GameObject.Find("GameManager").GetComponent<GameManager>()).GameOver();
    //Time.timeScale = 0;
    void OnCollisionEnter2D(Collision2D collision)
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
        if (collision.gameObject.CompareTag("DeathZone"))
        {
            PuntosSalud = 0;
        }
        if (collision.gameObject.CompareTag("Salud"))
        {
            PuntosSalud = 10;
        }
        if (collision.gameObject.CompareTag("disparoboss"))
        {
            PuntosSalud--; ;
        }

    }
    public void Dano()
    {
        if (PuntosSalud < 1)
        {
            (GameObject.Find("GameManager").GetComponent<GameManager>()).GameOver();
            
            Time.timeScale = 0;
        }
    }
    public void enDialogo()
    {
        InDialogue = true;
        FindObjectOfType<TriggerTexto>().enDialogo();
    }
    public void fueraDialogo()
    {
        InDialogue = false;
        FindObjectOfType<TriggerTexto>().fueraDialogo();
    }
    public void rangoDialogo()
    {
        rangodialogo = true;
    }
    public void fueraRangoDialogo()
    {
        rangodialogo = false;
    }




}
