using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlayerVRLeft : MonoBehaviour
{
    Interacteable interacteableVR;
    Movimiento player;

    void Awake()
    {
        player = FindObjectOfType<Movimiento>();
        interacteableVR = GetComponent<Interacteable>();
    }

    private void Update()
    {
        if (!interacteableVR.isPressed)
        {
            DejarDoblarIzquierda();
            return;
        }
        else
        {
            DoblarIzquierda();
        }
    }

    public void DoblarIzquierda()
    {
        player.izquierda = true;
    }

    public void DejarDoblarIzquierda()
    {
        player.izquierda = false;
    }
}
