using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Opciones", menuName ="Herramientas/Opciones", order =1)]

public class Opciones : PuntajePersistente
{
    public float velocidadBolaSO = 30; 
    public dificultad NivelDificultad = dificultad.facil;

    public enum dificultad:int
    {
        facil=1,
        normal=2,
        dificil=3
    }
    
    public void CambiarVelocidad(float nuevaVelocidad)
    {
        velocidadBolaSO = nuevaVelocidad;
    }

    public void CambiarDificultad(int nuevaDificultad)
    {
        NivelDificultad = (dificultad)nuevaDificultad;
    }
}
//velocidadBolaSO.Cargar();
//velocidadBola = velocidadBolaSO.velocidadBola;