using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovimiento : MonoBehaviour
{
    public Transform puntoA;
    public Transform puntoB;
    public float velocidad = 2f; 
    private Vector3 objetivoActual;
    private bool moviendoA;

    private PlayerInputActions inputActions;
    private Vector2 inputMovimiento;

    void Awake()
    {
        inputActions = new PlayerInputActions();
    }

    void OnEnable()
    {
        inputActions.Player.Move.Enable();
    }

    void OnDisable()
    {
        inputActions.Player.Move.Disable();
    }

    void Start()
    {
        transform.position = puntoA.position;
        objetivoActual = puntoB.position;
        moviendoA = false;
    }

    void Update()
    {
        inputMovimiento = inputActions.Player.Move.ReadValue<Vector2>();


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
