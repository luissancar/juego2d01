using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo2 : MonoBehaviour
{
   
    public float velocidad;
    public Vector3 posicionInicio;
    public Vector3 posicionFinal;
    private bool moviendoAFin;
    // Start is called before the first frame update
    void Start()
    {
        posicionInicio = transform.position;
        posicionFinal = new Vector3(posicionInicio.x +4, posicionInicio.y, posicionInicio.z);
        moviendoAFin = true;
        velocidad = 0.5f;

    }

    // Update is called once per frame
    void Update()
    {
        MoverEnemigo();
    }

    private void MoverEnemigo()
    {
        Vector3 posicionDestino = (moviendoAFin) ? posicionFinal : posicionInicio;
        transform.position = Vector3.MoveTowards(transform.position, posicionDestino,
            velocidad * Time.deltaTime);
        if (transform.position == posicionFinal)
            moviendoAFin = false;
        if (transform.position == posicionInicio)
            moviendoAFin = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Jugador>().QuitarVidas();
           
            // collision.gameObject.GetComponent<Jugador>().FinJuego();

        }
    }
}
