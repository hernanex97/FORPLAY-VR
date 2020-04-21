using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pointer : MonoBehaviour
{
    public float distance;
    public LineRenderer lineRenderer = null;
    public LayerMask everythingMask = 0;
    public LayerMask interacteableMask = 0;
    public UnityAction<Vector3, GameObject> onPointerUpdate = null;

    private Transform currentOrigin = null;
    private GameObject currentObject = null;

    private void Awake()
    {
        PlayerEvents.onControllerSource += UpdateOrigin;
        PlayerEvents.onTouchPadDown += ProcessTouchPadDown;
    }

    private void Start()
    {
        SetLineColor();
    }

    private void Update()
    {
        Vector3 hitPoint = UpdateLine();
        currentObject = UpdatePointerStatus();
        if (onPointerUpdate != null) onPointerUpdate(hitPoint, currentObject);
    }

    private void OnDestroy()
    {
        PlayerEvents.onControllerSource -= UpdateOrigin;
        PlayerEvents.onTouchPadDown -= ProcessTouchPadDown;
    }
    
    private Vector3 UpdateLine()
    {
        //Create ray
        RaycastHit hit = CreateRaycast(everythingMask);

        //Set default end of ray 
        Vector3 endPosition = currentOrigin.position + (currentOrigin.forward * distance);
        //Check hit
        if (hit.collider != null) endPosition = hit.point;

        //Set position 
        lineRenderer.SetPosition(0, currentOrigin.position);
        lineRenderer.SetPosition(1, endPosition);

        return endPosition;
    }

    private void UpdateOrigin(OVRInput.Controller controller, GameObject controllerObject)
    {
        //Set origin of pointer
        currentOrigin = controllerObject.transform;
        //Is the laser visible?
        if(controller == OVRInput.Controller.Touchpad)
        {
            lineRenderer.enabled = false;
        }
        else
        {
            lineRenderer.enabled = true;
        }
    }

    private GameObject UpdatePointerStatus()
    {
        //Create Ray
        RaycastHit hit = CreateRaycast(interacteableMask);

        //Check hit
        if (hit.collider) return hit.collider.gameObject;

        //Return
        return null;
    }


    private RaycastHit CreateRaycast(int layer)
    {
        RaycastHit hit;
        Ray ray = new Ray(currentOrigin.position, currentOrigin.forward);
        Physics.Raycast(ray, out hit, distance, layer);
        return hit;
    }
    
    private void SetLineColor()
    {
        if (!lineRenderer) return;
        Color endColor = Color.white;
        endColor.a = 0.0f;
        lineRenderer.endColor = endColor;
    }

    private void ProcessTouchPadDown()
    {
        if (!currentObject) return;
        

        if(currentObject)
        {
            Interacteable interacteable = currentObject.GetComponent<Interacteable>();
            interacteable.Pressed();
        }
    }

    
    





}
