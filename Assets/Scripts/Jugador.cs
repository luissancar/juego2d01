using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jugador : MonoBehaviour
{

    public int velocidad;
    public Rigidbody2D jugador;
    public SpriteRenderer sprite;
    private int fuerzaSalto;
    private Animator animator;

    public int puntuacion;


    public int vidas;
    private bool vulnerable;

    public int tiempoNivel;
    private float tiempoInicio;
    private int tiempoEmpleado;
    public int numeroPowerUps;
    public Canvas canvas;
    private ControlHud hud;


    public AudioClip sonidoPowerUp;
    public AudioClip sonidoVida;

    private AudioSource audio;

    private ControlDatosJuego datosJuego;


    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        jugador = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();  

        velocidad = 10;
        fuerzaSalto = 12;

        vulnerable = true;
        tiempoInicio = Time.time;
        numeroPowerUps = 3;
       
        hud =canvas.GetComponent<ControlHud>();
        hud.SetPowerUps(numeroPowerUps);
        hud.SetVidas(vidas);


        datosJuego = GameObject.Find("DatosJuego").GetComponent<ControlDatosJuego>();
    }

    // Update is called once per frame
    void Update()
    {
        if (jugador.velocity.x > 0)
        {
            sprite.flipX = false;
        }
        else
            if (jugador.velocity.x < 0)
            sprite.flipX = true;
        if (Input.GetKeyDown(KeyCode.Space) && TocandoSuelo())
        {
            jugador.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);

            Debug.Log("Salto");
        }
        AnimarJugador();
        tiempoEmpleado = (int)Time.time - (int)tiempoInicio;
        if (tiempoNivel-tiempoEmpleado <0)
            Perdido();
        if (numeroPowerUps == 0)
        {
            Ganado();
        }
        hud.SetTiempo(tiempoEmpleado);
        

    }

    private void Ganado()
    {
        
        SceneManager.LoadScene("Ganado");
        datosJuego.Ganado = true;
        Debug.Log("Ganado");
    }

    private void Perdido()
    {
        datosJuego.Ganado = false;
        SceneManager.LoadScene("Menu");
    }

    public void IncrementarPuntuacion(int puntos)
    {
        puntuacion += puntos;
    }

    public void DecrementarPowerUps()
    {
        audio.PlayOneShot(sonidoPowerUp);
        numeroPowerUps--;
        hud.SetPowerUps(numeroPowerUps);
        datosJuego.Puntuacion = datosJuego.Puntuacion + 5;
    }

    private void AnimarJugador()
    {
        if (!TocandoSuelo())
            animator.Play("JugadorSaltando");
        else
            if (jugador.velocity.x > 1 || jugador.velocity.x < -1
                    && jugador.velocity.y == 0)
            animator.Play("JugadorCorriendo");
            else
                if (jugador.velocity.x < 1 || jugador.velocity.x > -1
                        && jugador.velocity.y == 0)
                    animator.Play("JugadorParado");


    }

    private void FixedUpdate()
    {
        float entradaX = Input.GetAxis("Horizontal");

        Debug.Log(TocandoSuelo());
        jugador.velocity = new Vector2(entradaX*velocidad,jugador.velocity.y);
        
    }

    private bool TocandoSuelo()
    {
        RaycastHit2D toca = Physics2D.Raycast(transform.position + new Vector3(0, -2f, 0), 
                Vector2.down, 0.2f);
        return toca.collider != null;
        
    }

    public void FinJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void HacerVulnerable()
    {
        vulnerable = true;
        sprite.color=Color.white;
    }

    public void QuitarVidas()
    {
        if (vulnerable)
        {
            vulnerable = false;
            if (--vidas == 0)
            {
                Perdido();
            }
            hud.SetVidas(vidas);
            audio.PlayOneShot(sonidoVida);
            sprite.color = Color.red;
            Invoke("HacerVulnerable", 1f);
        }
    }

}
