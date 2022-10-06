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
        transformPuntajeActual = GameObject.Find("PuntuajeActual").transform;
        transformPuntajeAlto = GameObject.Find("PuntuajeAlto").transform;
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

    private void FixedUpdate() 
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        textoActual.text = $"PuntuajeActual: {puntajeAltoSO.puntaje}";
        if(puntajeAltoSO.puntaje > puntajeAltoSO.puntajeAlto)
        {
            puntajeAltoSO.puntajeAlto = puntajeAltoSO.puntaje;
            textoPuntajeAlto.text =  $"PuntuajeAlto: {puntajeAltoSO.puntajeAlto}";
        }
        // textoActual.text = $"PuntuajeActual: {puntos}";
        // if(puntos > puntuajeAlto)
        // {
        //     puntuajeAlto = puntos;
        //     textoPuntajeAlto.text =  $"PuntuajeActual: {puntos}";
        //     PlayerPrefs.SetInt("PuntuajeAlto", puntos); //Manera antigua de sistema de guardado
        // }
    }


    public void AumentarPuntuaje(int puntos)
    {
        puntajeAltoSO.puntaje += puntos;
    }
}
