using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliciaPlayer2 : MonoBehaviour
{
    [Header("Vida Policia (Player 2)")]
    public int vida = 100;

    [Header("Parámetros velocidad y movimiento (Player 2)")]
    public float velocidadInicial = 0;
    public float velocidadFrontal = 10;
    public float velocidadRotacion = 50;

    [Header("Componentes (Player 2)")]
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(Physics.gravity * (rb.mass * rb.mass));

        velocidadRotacion = 100;
        Vector3 newPosition = rb.position + transform.TransformDirection(0, 0, velocidadFrontal * Time.deltaTime);
        rb.MovePosition(newPosition);

        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Rotate(0, velocidadRotacion * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.Rotate(0, -velocidadRotacion * Time.deltaTime, 0);
        }
        

    }
}





