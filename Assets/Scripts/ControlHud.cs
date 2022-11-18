using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControlHud : MonoBehaviour
{
    public TextMeshProUGUI vidasTxt;
    public TextMeshProUGUI tiempoTxt;
    public TextMeshProUGUI powerUpsTxt;
    public void SetVidas(int vidas)
    {
        vidasTxt.text = "Vidas: " + vidas;
    }
    public void SetTiempo(int tiempo)
    {

        int segundos = tiempo % 60;
        int minutos = tiempo / 60;

        tiempoTxt.text = minutos.ToString("00")+":"+segundos.ToString("00");
    }
    public void SetPowerUps(int powerUps)
    {
        powerUpsTxt.text = "PowerUps " + powerUps;
    }

}
