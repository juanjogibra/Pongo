using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PelotaScript : MonoBehaviour {

    private Rigidbody2D rb2d;
    public GameManager game;
    public float speed;
    public AudioSource rebote;
    public AudioSource rebotePared;


    private int vidasIz = 5;
    private int vidasDer = 5;
    private int puntosIz = 0;
    private int puntosDer = 0;

    public Text contadorDerecha;
    public Text contadorIzquierda;
    public Text puntuacionIzquierda;
    public Text puntuacionDerecha;
    public Text avisoNivel;


    public Button reiniciar;
    public Text ganar;
    public KeyCode nuevaEscena;



    // Start is called before the first frame update
    void GoBall()
    {
        float rand = Random.Range(0, 2);
        if (rand < 1)
        {
            rb2d.AddForce(new Vector2(20, -15)*speed);
            
        }
        else
        {
            rb2d.AddForce(new Vector2(-20, -15)*speed);
        }
    }
    void ResetBall()
    {
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }
    void RestartGame()
    {
        ResetBall();
        Invoke("GoBall", 1);
    }
    
     void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("palaizquierda") || (coll.collider.CompareTag("paladerecha")))
        {
            Vector2 vel;
            vel.x = rb2d.velocity.x;
            vel.y = (rb2d.velocity.y / 2) + (coll.collider.attachedRigidbody.velocity.y / 3);
            rb2d.velocity = vel;

           
            
        }
        if (coll.gameObject.tag == "palaizquierda")
        {
            puntosIz++;
            rebote.Play();

        }
        if (coll.gameObject.tag == "paladerecha")
        {
            puntosDer++;
            rebote.Play();

        }

        if (vidasIz == 0)
        {
            ganar.text = "Has ganado, Jugador 2";

            ganar.gameObject.SetActive(true);
            reiniciar.gameObject.SetActive(true);
            Time.timeScale = 0f;


        }
        if (vidasDer == 0)
        {
            ganar.text = "Has ganado, Jugador 1";
            ganar.gameObject.SetActive(true);
            reiniciar.gameObject.SetActive(true);
            Time.timeScale = 0f;

        }
        actualizarIzquierdo();
        actualizarDerecha();

        if (coll.gameObject.tag=="paredderecha")
        {
            vidasDer--;
            rebotePared.Play();


        }
        if (coll.gameObject.tag == "paredizquierda")
        {
            vidasIz--;
            rebotePared.Play();

        }
        if (coll.gameObject.tag == "paredhorizontal")
        {            
            rebotePared.Play();
        }


    }
    void Start()
    {
        reiniciar.gameObject.SetActive(false);
        ganar.gameObject.SetActive(false);
        avisoNivel.gameObject.SetActive(false);

        rb2d = GetComponent<Rigidbody2D>();
        Invoke("GoBall", 1);
       // rebote = GetComponent<AudioSource>();



    }

    // Update is called once per frame
    void Update()
    {
        //Pa cuando la bola se quede atrancá
        if (Input.GetKeyDown("space"))
        {
            rb2d.AddForce(new Vector2(20, -15) * speed);
        }

        // if (Input.GetKey(nuevaEscena))
        //  {
        //     SceneManager.LoadScene("escena2");
        //  }
        if ((puntosDer == 7) || (puntosIz == 7))
        {
            avisoNivel.gameObject.SetActive(true);


            if (Input.GetKey(nuevaEscena))
            {
                SceneManager.LoadScene("escena2");
            }
        }
    }


    //Actualiza los textos de la derecha
    private void actualizarDerecha()
    {
        contadorDerecha.text = "VidasJ1: " + vidasIz;
        puntuacionDerecha.text = "Puntos Jugador 2: " + puntosDer;
        
    }
    //Actualiza los textos de la izquierda
    private void actualizarIzquierdo()
    {
        contadorIzquierda.text = "VidasJ2: " + vidasDer;
        puntuacionIzquierda.text = "Puntos Jugador 1: " + puntosIz;
       

    }

}
