using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reticule : MonoBehaviour
{
    public Pointer pointer;
    public SpriteRenderer circleRenderer;
    public Sprite openSprite;
    public Sprite closedSprite;

    private Camera cam = null;

    private void Awake()
    {
        pointer.onPointerUpdate += UpdateSprite;
        cam = Camera.main;
    }

    void Update()
    {
        transform.LookAt(cam.gameObject.transform);
        
    }

    private void OnDestroy()
    {
        pointer.onPointerUpdate -= UpdateSprite;
    }

    private void UpdateSprite(Vector3 point, GameObject hitObject)
    {
        transform.position = point;
        if(hitObject)
        {
            circleRenderer.sprite = closedSprite;
        }
        else
        {
            circleRenderer.sprite = openSprite;
        }
    }
}
