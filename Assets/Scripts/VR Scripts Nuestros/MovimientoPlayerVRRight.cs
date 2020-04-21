using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlayerVRRight : MonoBehaviour
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
            DejarDoblarDerecha();
            return;
        }
        else
        {
            DoblarDerecha();
        }
    }

    public void DoblarDerecha()
    {
        player.derecha = true;
    }

    public void DejarDoblarDerecha()
    {
        player.derecha = false;
    }

}
