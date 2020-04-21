using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CargarJuego : MonoBehaviour
{
    private Interacteable interacteableVR;
    [SerializeField]
    private string nameScene;

    private void Awake()
    {
        interacteableVR = GetComponent<Interacteable>();
    }

    private void Update()
    {
        if (!interacteableVR.isPressed)
        {
            return;
        }
        else
        {
            CargarNivel(nameScene);
        }
    }

    public void CargarNivel(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }
}
