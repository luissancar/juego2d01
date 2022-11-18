using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPowerUp : MonoBehaviour
{
    public int cantidad;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Jugador>().IncrementarPuntuacion(cantidad);
            collision.gameObject.GetComponent<Jugador>().DecrementarPowerUps();
            Destroy(gameObject);
        }
    }
}
