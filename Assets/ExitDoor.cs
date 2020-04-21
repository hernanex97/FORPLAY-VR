using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    private Interacteable interactableVR;

    private void Awake()
    {
        interactableVR = GetComponent<Interacteable>();
    }

    private void Update()
    {
        if (!interactableVR.isPressed)
        {
            return;
        }
        else
        {
            Quit();
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
