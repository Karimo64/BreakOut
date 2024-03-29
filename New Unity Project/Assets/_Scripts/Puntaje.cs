using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Puntaje : MonoBehaviour
{
    public Transform transformPuntajeAlto;
    public Transform transformPuntajeActual;
    public TMP_Text textoPuntajeAlto;
    public TMP_Text textoActual;
    public PuntajeAlto puntajeAltoSO;
    // public int puntos = 0;
    // public int puntuajeAlto = 1000;
    // Start is called before the first frame update
    void Start()
    {
        transformPuntajeActual = GameObject.Find("PuntajeActual").transform;
        transformPuntajeAlto = GameObject.Find("PuntajeAlto").transform;
        textoActual = transformPuntajeActual.GetComponent<TMP_Text>();
        textoPuntajeAlto = transformPuntajeAlto.GetComponent<TMP_Text>();
        //if (PlayerPrefs.HasKey("PuntuajeAlto")) //Manera antigua de sistema de guardado
        //{
            // puntuajeAlto = PlayerPrefs.GetInt("PuntuajeAlto");
        //}
        puntajeAltoSO.Cargar();
        textoPuntajeAlto.text = $"PuntajeAlto: {puntajeAltoSO.puntajeAlto}";
        puntajeAltoSO.puntaje = 0;
    }

    
    // Update is called once per frame
    void Update()
    {
        textoActual.text = $"PuntajeActual: {puntajeAltoSO.puntaje}";
        if(puntajeAltoSO.puntaje > puntajeAltoSO.puntajeAlto)
        {
            puntajeAltoSO.puntajeAlto = puntajeAltoSO.puntaje;
            textoPuntajeAlto.text =  $"PuntajeAlto: {puntajeAltoSO.puntajeAlto}";
            puntajeAltoSO.Guardar();
        }
        // textoActual.text = $"PuntuajeActual: {puntos}";
        // if(puntos > puntuajeAlto)
        // {
        //     puntuajeAlto = puntos;
        //     textoPuntajeAlto.text =  $"PuntuajeActual: {puntos}";
        //     PlayerPrefs.SetInt("PuntuajeAlto", puntos); //Manera antigua de sistema de guardado
        // }
    }


//    private void FixedUpdate() 
//     {
//         puntajeAltoSO.puntaje += 10;
//     }

    public void AumentarPuntaje(int puntos)
    {
        puntajeAltoSO.puntaje += puntos;
    }
}
