using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class movimiento : MonoBehaviour
{
    public Transform puntoA;
    public Transform puntoB;
    public float velocidad = 2f; 

    private Vector3 objetivoActual;
    private bool moviendoA;

    void Start()
    {
        
        transform.position = puntoA.position;
        objetivoActual = puntoB.position;
        moviendoA = false;
    }
    void Update()
    {
        
        transform.position = Vector3.MoveTowards(transform.position, objetivoActual, velocidad * Time.deltaTime);

        if (Vector3.Distance(transform.position, objetivoActual) < 0.1f)
        {
            if (moviendoA)
            {
                objetivoActual = puntoB.position;
                moviendoA = false;
            }
            else
            {
                objetivoActual = puntoA.position;
                moviendoA = true;
            }
        }
    }
}
