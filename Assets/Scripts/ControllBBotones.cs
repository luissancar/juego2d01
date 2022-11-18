using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllBBotones : MonoBehaviour
{
    public void OnJugar()
    {
        SceneManager.LoadScene("Nivel1");
    }

    public void OnCreditos()
    {
        SceneManager.LoadScene("Creditos");
    }
    public void OnSalir()
    {
        Application.Quit();
    }

    public void OnMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
