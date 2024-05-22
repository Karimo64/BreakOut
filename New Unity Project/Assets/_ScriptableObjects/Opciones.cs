using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Opciones", menuName ="Herramientas/Opciones", order =1)]

public class Opciones : PuntajePersistente
{
    public float velocidadBolaSO = 30; 
    public dificultad NivelDificultadSO = dificultad.facil;

    public enum dificultad:int
    {
        facil,
        normal,
        dificil
    }
    
    public void CambiarVelocidad(float nuevaVelocidad)
    {
        velocidadBolaSO = nuevaVelocidad;
    }

    public void CambiarDificultad(int nuevaDificultad)
    {
        NivelDificultadSO = (dificultad)nuevaDificultad;
    }
}
//velocidadBolaSO.Cargar();
//velocidadBola = velocidadBolaSO.velocidadBola;