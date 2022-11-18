using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Efecto Parallax
public class EfectoParallax : MonoBehaviour
{

    public float efectoParallax;
    private Transform camara;
    private Vector3 camarUltimaPos;

    // Start is called before the first frame update
    void Start()
    {
        camara=Camera.main.transform;
        camarUltimaPos=camara.position; 
        
    }

    private void LateUpdate()
    {
        Vector3 movimientoFondo =camara.position - camarUltimaPos;
        transform.position += new Vector3(movimientoFondo.x * efectoParallax
            , movimientoFondo.y, 0);
        camarUltimaPos = camara.position;
    }
}
