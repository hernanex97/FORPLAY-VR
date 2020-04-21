using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour {
    public float velocidadInicial = 0;
    public float velocidadFrontal = 10;
    public float velocidadRotacion = 50;
    //  public float angle = 0;
    // public int min = -45;
    //  public int max = 45;
    public AudioClip aceleracion;
    public Animator animator;
    //public ParticleSystem derrapeDerecha;
    //public ParticleSystem derrapeIzquierda;
    Vida vida;
    public Rigidbody _rb;
    //Celular
    public bool derecha = false;
    public bool izquierda = false;
    public bool turbo = false;

    //public ParticleSystem.EmissionModule emissionD;
    //public ParticleSystem.EmissionModule emissionI;

    public void Start () 
    {
        _rb = GetComponent<Rigidbody>();
        vida = GetComponent<Vida>();
        if (gameObject.tag == "Player")
            //  SonidoMotor();
        //derrapeDerecha = GetComponent<ParticleSystem>();
        //derrapeIzquierda = GetComponent<ParticleSystem>();
        animator = GetComponent<Animator>();

    }

    public void FixedUpdate() 
    {
        _rb.AddForce(Physics.gravity * (_rb.mass * _rb.mass));


        velocidadRotacion = 100;
        Vector3 newPosition = _rb.position + transform.TransformDirection(0, 0, velocidadFrontal * Time.deltaTime);
        _rb.MovePosition (newPosition);
        
        

        if (Input.GetKey(KeyCode.RightArrow ) || derecha)
        {
            //usar rigidbody para la rotacion tambien xd
            gameObject.transform.Rotate(0, velocidadRotacion * Time.deltaTime, 0);          
            //angle += velocidadRotacion;
            animator.SetBool("derecha", true);
            //emissionD.enabled = true;
            //emissionI.enabled = true;

        }
        else if(!derecha)
        {
            animator.SetBool("derecha", false);

            //emissionD.enabled = false;
            //emissionI.enabled = false;
        }

        if (Input.GetKey(KeyCode.LeftArrow) || izquierda)
        {
            // angle -= velocidadRotacion;
            gameObject.transform.Rotate(0,- velocidadRotacion * Time.deltaTime, 0);
            animator.SetBool("izquierda", true);

            //emissionD.enabled = true;
            //emissionI.enabled = true;

        }
        else if (!izquierda)
        {
            animator.SetBool("izquierda", false);

            //emissionD.enabled = false;
            //emissionI.enabled = false;
        }
 
        // transform.position = new Vector3(Mathf.Clamp(transform.position.x, -44f, 55f), Mathf.Clamp(transform.position.y,0f,4f), Mathf.Clamp(transform.position.z,-16f,341f));//para que no se caiga por los laterales
        //  transform.eulerAngles = new Vector3(0, angle, 0);
                                                                                                                                        //angle = Mathf.Clamp(angle, min, max);

    }



    
}

