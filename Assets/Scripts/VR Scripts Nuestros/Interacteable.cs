using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacteable : MonoBehaviour
{
    public bool isPressed;

    private void Awake()
    {
        isPressed = false;
    }

    public void Pressed()
    {
        isPressed = true;
    }


}
