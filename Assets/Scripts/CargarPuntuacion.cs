using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargarPuntuacion : MonoBehaviour
{



    private ControlDatosJuego datosJuego;

    // Start is called before the first frame update
    void Start()
    {

        datosJuego = GameObject.Find("DatosJuego").GetComponent<ControlDatosJuego>();
        Debug.Log(datosJuego.puntuacion);

    }

}
