using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bloque : MonoBehaviour
{
    public int resistencia; 
    public UnityEvent AumentarPuntaje;
    public Opciones opciones;

    public void Awake()
    {
       if(opciones == null)
        {
            opciones = FindObjectOfType<Opciones>();
        }
    }
    public void OnCollisionEnter(Collision collision) 
    {
        if(collision.gameObject.tag == "Bola")
        {
            RebotarBola(collision);
        }    
    }

    public virtual void RebotarBola (Collision collision)
    {
        Vector3 direccion = collision.contacts[0].point - transform.position;
        direccion = direccion.normalized;
        collision.rigidbody.velocity = collision.gameObject.GetComponent<Bola>().velocidadBola * direccion;
        resistencia--;
    }
    // Start is called before the first frame update
    protected virtual void Start()
    {
        UpdateResistanceBasedOnDifficulty();
    }

    protected virtual void Update()
    {
        if (resistencia <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void UpdateResistanceBasedOnDifficulty()
    {
        switch (opciones.NivelDificultadSO)
        {
            case Opciones.dificultad.facil:
                resistencia = 1;
                break;
            case Opciones.dificultad.normal:
                resistencia = 2;
                break;
            case Opciones.dificultad.dificil:
                resistencia = 3;
                break;
            default:
                resistencia = 1; // Default to easy difficulty
                break;
        }
        Debug.Log($"Updated resistance to {resistencia} based on difficulty {opciones.NivelDificultadSO}");
    }

}
