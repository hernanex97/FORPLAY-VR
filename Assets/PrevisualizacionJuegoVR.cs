using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrevisualizacionJuegoVR : MonoBehaviour
{
    private Interacteable interacteableVR;
    public GameObject board;
    
    void Awake()
    {
        interacteableVR = GetComponent<Interacteable>();
        board.SetActive(false); 
    }

    public void Update()
    {
        if (!interacteableVR.isPressed)
        {
            return;
        }
        else
        {
            Functionality();
        }
    }

    public void Functionality()
    {
        board.SetActive(true);
    }
}
