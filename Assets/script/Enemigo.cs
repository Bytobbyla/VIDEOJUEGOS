using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int PuntosSaludEnemigo;
    public int rutina;
    public float cronometro;
    public Animator ani;
    public int direction;
    public float speed_walk;
    public float speed_run;
    public GameObject target;
    public bool atacando;

    public float rango_vision;
    public float rango_ataque;
    public GameObject rango;
    public GameObject Hit;
    [SerializeField] AudioClip sfx_death;
    [SerializeField] AudioClip sfx_attack;





    //variable para guardar jugador

    void Start()
    {
        ani = GetComponent<Animator>();
        target = GameObject.Find("personaje");
        
    }

    // Update is called once per frame
    void Update()
    {
        Comportamientos();
        

    }
    public void Final_Ani()
    {
        ani.SetBool("attack", false);
        atacando = false;
        rango.GetComponent<BoxCollider2D>().enabled = true;
    }
    public void ColliderWeaponTrue()
    {
        AudioSource.PlayClipAtPoint(sfx_attack, Camera.main.transform.position);
        Hit.GetComponent<BoxCollider2D>().enabled = true;
    }
    public void ColliderWeaponFalse()
    {
        Hit.GetComponent<BoxCollider2D>().enabled = false;
    }
    public void Comportamientos()
    {
        if(Mathf.Abs(transform.position.x - target.transform.position.x)> rango_vision && !atacando)
        {
            ani.SetBool("run", false);
            cronometro += 1 * Time.deltaTime;
            if (cronometro >= 2)
            {
                rutina = Random.Range(0, 2);
                cronometro = 0;
            }
            switch (rutina)
            {
                case 0:
                    ani.SetBool("walk", false);
                    break;
                case 1:
                    direction = Random.Range(0, 2);
                    rutina++;
                    break;

                case 2:
                    switch (direction)
                    {
                        case 0:
                            transform.rotation = Quaternion.Euler(0, 0, 0);
                            transform.Translate(Vector3.right * speed_walk * Time.deltaTime);
                            break;
                        case 1:
                            transform.rotation = Quaternion.Euler(0, 180, 0);
                            transform.Translate(Vector3.right * speed_walk * Time.deltaTime);
                            break;

                    }
                    ani.SetBool("walk", true);
                    break;
            }


       


        }
        else
        {
            //Comportamiento persecucion
            if (Mathf.Abs(transform.position.x - target.transform.position.x) > rango_ataque && !atacando)
            {
                if(transform.position.x < target.transform.position.x)
                {
                    ani.SetBool("walk", false);
                    ani.SetBool("run", true);
                    transform.Translate(Vector3.right * speed_run * Time.deltaTime);
                    transform.rotation = Quaternion.Euler(0,0,0);
                    ani.SetBool("attack", false);

                }
                else
                {
                    ani.SetBool("walk", false);
                    ani.SetBool("run", true);
                    transform.Translate(Vector3.right * speed_run * Time.deltaTime);
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                    ani.SetBool("attack", false);
                }

            }
            else
            {
                if (!atacando)
                {
                    if (transform.position.x < target.transform.position.x)
                    {
                        transform.rotation = Quaternion.Euler(0, 0, 0);
                    }
                    else
                    {
                        transform.rotation = Quaternion.Euler(0, 180, 0);
                    }
                    ani.SetBool("walk", false);
                    ani.SetBool("run", false);

                }

            }
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
                AudioSource.PlayClipAtPoint(sfx_death, Camera.main.transform.position);
                Destroy(this.gameObject);
            }


        }
    }
}
