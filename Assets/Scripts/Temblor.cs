using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this es camara
public class Temblor : MonoBehaviour
{
    private float duracionTemblor;
    // Start is called before the first frame update
    void Start()
    {
        duracionTemblor = 1f;
    }


    private void Update()
    {
        StartCoroutine(TemblorPantalla());
    }

    IEnumerator TemblorPantalla()
    {
        Vector3 PosicionInicial=this.transform.position;
        float tiempoTranscurrido = 0f;

        while (tiempoTranscurrido < duracionTemblor)
        {
            tiempoTranscurrido+=Time.deltaTime;
            transform.position = PosicionInicial+Random.insideUnitSphere; // mueve aleatoriamente en un metro
            yield return null;
        }
        transform.position = PosicionInicial;


    }

}
