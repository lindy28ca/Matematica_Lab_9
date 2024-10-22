using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class movimientoMRUV : MonoBehaviour
{
    public Transform objetivo; 
    public float velocidadInicial = 1f;
    public float aceleracion = 0.5f; 
    private float velocidadActual;

    void Start()
    {
        velocidadActual = velocidadInicial;
    }

    void Update()
    {
        Vector3 direccion = (objetivo.position - transform.position).normalized;

        transform.position += direccion * velocidadActual * Time.deltaTime;

        velocidadActual += aceleracion * Time.deltaTime;
    }
}
