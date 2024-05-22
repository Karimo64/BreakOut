using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bola : MonoBehaviour
{
    public bool isGameStarted;
    [SerializeField] public float velocidadBola = 10.0f;
    Vector3 ultimaPosicion = Vector3.zero;
    Vector3 direccion = Vector3.zero;
    Rigidbody rigidbody;
    private ControlBordes control;
    public UnityEvent BolaDestruida;
    public Opciones opcionesSO;

    private void Awake()
    {
        control = GetComponent<ControlBordes>();
    }

    void Start()
    {
        isGameStarted = false;
        Vector3 posInicial = GameObject.FindGameObjectWithTag("Jugador").transform.position;
        posInicial.y += 3;
        this.transform.position = posInicial;
        this.transform.SetParent(GameObject.FindGameObjectWithTag("Jugador").transform);
        rigidbody = this.gameObject.GetComponent<Rigidbody>();

        if (opcionesSO != null)
        {
            velocidadBola = opcionesSO.velocidadBolaSO;
            Debug.Log($"Initial speed set from ScriptableObject: {velocidadBola}");
        }
    }

    void Update()
    {
        if (opcionesSO != null)
        {
            velocidadBola = opcionesSO.velocidadBolaSO;
            Debug.Log($"Speed updated from ScriptableObject: {velocidadBola}");
        }
        else
        {
            Debug.LogError("Opciones ScriptableObject is not assigned.");
        }

        if (control.salioAbajo)
        {
            BolaDestruida.Invoke();
            Destroy(this.gameObject);
        }
        if (control.salioArriba)
        {
            direccion = transform.position - ultimaPosicion;
            Debug.Log("La bola toco el borde superior");
            direccion.y *= -1;
            direccion = direccion.normalized;
            rigidbody.velocity = velocidadBola * direccion;
            control.salioArriba = false;
            control.enabled = false;
            Invoke("HabilitarControl", 0.5f);
        }
        if (control.salioDerecha)
        {
            direccion = transform.position - ultimaPosicion;
            Debug.Log("La bola toco el borde derecho");
            direccion.x *= -1;
            direccion = direccion.normalized;
            rigidbody.velocity = velocidadBola * direccion;
            control.salioDerecha = false;
            control.enabled = false;
            Invoke("HabilitarControl", 0.5f);
        }
        if (control.salioIzquierda)
        {
            direccion = transform.position - ultimaPosicion;
            Debug.Log("La bola toco el borde izquierdo");
            direccion.x *= -1;
            direccion = direccion.normalized;
            rigidbody.velocity = velocidadBola * direccion;
            control.salioIzquierda = false;
            control.enabled = false;
            Invoke("HabilitarControl", 0.5f);
        }

        if (Input.GetKey(KeyCode.Space) || Input.GetButton("Submit"))
        {
            if (!isGameStarted)
            {
                isGameStarted = true;
                this.transform.SetParent(null);
                rigidbody.velocity = velocidadBola * Vector3.up;
            }
        }
    }

    private void HabilitarControl()
    {
        control.enabled = true;
    }

    private void FixedUpdate()
    {
        ultimaPosicion = transform.position;
    }

    public void LateUpdate()
    {
        if (direccion != Vector3.zero) direccion = Vector3.zero;
    }
}

