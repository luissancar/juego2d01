using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControlTextoGAnado : MonoBehaviour
{
    
    public TextMeshProUGUI puntuacionTxt;

    private ControlDatosJuego datosJuego;

    private void Start()
    {

        datosJuego = GameObject.Find("DatosJuego").GetComponent<ControlDatosJuego>();
        SetPuntuacion(datosJuego.Puntuacion);
    }
    public void SetPuntuacion(int puntos)
    {
        puntuacionTxt.text = "Puntos: " + puntos;
        Debug.Log("ddddd");
    }
}
