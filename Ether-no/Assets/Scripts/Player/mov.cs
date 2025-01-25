using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class mov : MonoBehaviour
{
    public float velocidadMovimiento;

    private Vector2 direccion;

    private Rigidbody2D rb;

    private float movimientoX;
    private float movimientoY;
    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        movimientoX = Input.GetAxisRaw("Horizontal");
        movimientoY = Input.GetAxisRaw("Vertical");
        animator.SetFloat("MovimientoX", movimientoX);
        animator.SetFloat("MovimientoY", movimientoY);

        if(movimientoX != 0 || movimientoY != 0)
        {
            animator.SetFloat("UltimoX", movimientoX);
            animator.SetFloat("UltimoY", movimientoY);
        }



        direccion = new Vector2(movimientoX, movimientoY).normalized;

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + direccion * velocidadMovimiento * Time.fixedDeltaTime);
    }
}

