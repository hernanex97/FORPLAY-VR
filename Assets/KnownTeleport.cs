using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnownTeleport : MonoBehaviour
{
    [Header("Teleports Verticales")]
    public GameObject tp1a;
    public GameObject tp2a;
    public GameObject tp3a;
    public GameObject tp1b;
    public GameObject tp2b;
    public GameObject tp3b;

    [Header("Teleports Horizontales")]
    public GameObject tpIzquierda; //pared izquierda
    public GameObject tpDerecha; //pared derecha
    public BoxCollider playerTPCollider;
    public GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerTPCollider = player.GetComponentInChildren<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        #region  Teleports //tocar acá ->
        if (other.gameObject.tag == "TP2B")
        {
            playerTPCollider.enabled = false;
            this.transform.position = new Vector3(tp2a.transform.position.x, tp2a.transform.position.y, tp2a.transform.position.z);
        }

        if (other.gameObject.tag == "TP1A")
        {
            playerTPCollider.enabled = false;
            player.transform.position = new Vector3(tp1b.transform.position.x, tp1b.transform.position.y, tp1b.transform.position.z);
            Invoke("EncenderCollderTP", 1f);
        }

        if (other.gameObject.tag == "TP3A")
        {
            playerTPCollider.enabled = false;
            this.transform.position = new Vector3(tp3b.transform.position.x, tp3b.transform.position.y, tp3b.transform.position.z);
        }

        if (other.gameObject.tag == "tpDerecha")
        {
            if (transform.eulerAngles.y >= 268)
            {
                playerTPCollider.enabled = false;
                this.transform.position = new Vector3(tpIzquierda.transform.position.x, tpIzquierda.transform.position.y, tpIzquierda.transform.position.z);
            }
        }

        if (other.gameObject.tag == "tpIzquierda")
        {
            if (transform.eulerAngles.y >= 80 && transform.eulerAngles.y <= 92)
            {
                playerTPCollider.enabled = false;
                this.transform.position = new Vector3(tpDerecha.transform.position.x, tpDerecha.transform.position.y, tpDerecha.transform.position.z);
            }
        }
        #endregion
    }

    public void EncenderCollderTP()
    {
        playerTPCollider.enabled = true;
    }

}
