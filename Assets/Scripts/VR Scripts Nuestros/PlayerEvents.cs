using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerEvents : MonoBehaviour
{
    #region Events
    public static UnityAction onTouchPadUp = null;
    public static UnityAction onTouchPadDown = null;
    public static UnityAction<OVRInput.Controller, GameObject> onControllerSource = null;
    #endregion



    #region Anchors
    public GameObject leftAnchor;
    public GameObject rightAnchor;
    public GameObject headAnchor;
    #endregion

    #region Input
    private Dictionary<OVRInput.Controller, GameObject> controllerSets = null;
    private OVRInput.Controller inputSource = OVRInput.Controller.None;
    private OVRInput.Controller activeController = OVRInput.Controller.None;
    private bool inputActive = true;
    #endregion

    private void Awake()
    {
        OVRManager.HMDMounted += PlayerFound;
        OVRManager.HMDUnmounted += PlayerLost;
        controllerSets = CreateControllerSets();
    }

    private void OnDestroy()
    {
        OVRManager.HMDMounted -= PlayerFound;
        OVRManager.HMDUnmounted -= PlayerLost;
    }

    private void Update()
    {
        //check for avtive input
        if (!inputActive) return;

        //check if a controller exists
        CheckForController();
        //check for input source
        CheckInputSource();

        //Check fopr actual input
        Input();
    }

    private void CheckForController()
    {
        OVRInput.Controller controllerCheck = activeController;
        //right remote
        if(OVRInput.IsControllerConnected(OVRInput.Controller.RTrackedRemote))
        {
            controllerCheck = OVRInput.Controller.RTrackedRemote;
        }
        //left remote
        if (OVRInput.IsControllerConnected(OVRInput.Controller.LTrackedRemote))
        {
            controllerCheck = OVRInput.Controller.LTrackedRemote;
        }
        //if no controller, headset
        if (OVRInput.IsControllerConnected(OVRInput.Controller.RTrackedRemote) && (OVRInput.IsControllerConnected(OVRInput.Controller.LTrackedRemote)))
        {
            controllerCheck = OVRInput.Controller.Touchpad;
        }

        //Update the proyect
        activeController = UpdateSource(controllerCheck, activeController);
    }

    private void CheckInputSource()
    {
        //Update
        inputSource = UpdateSource(OVRInput.GetActiveController(), inputSource);
    }

    private void Input()
    {
        //Touchpad Down
        if (OVRInput.GetDown(OVRInput.Button.PrimaryTouchpad))
        {
            if (onTouchPadDown != null)
            {
                onTouchPadDown();
            } 
        }

        //Touchpad Up
        if (OVRInput.GetUp(OVRInput.Button.PrimaryTouchpad))
        {
            if (onTouchPadUp != null) onTouchPadUp();
        }
    }

    private OVRInput.Controller UpdateSource(OVRInput.Controller check, OVRInput.Controller previous)
    {
        //if values are the same.. return
        if (check == previous) return previous;

        //get controller object
        GameObject controllerObject = null;
        controllerSets.TryGetValue(check, out controllerObject);

        //if no controller, set to the head
        if (controllerObject == null) controllerObject = headAnchor;

        //send out event
        if (onControllerSource != null) onControllerSource(check, controllerObject);

        //return new value
        return check;
    }


    private void PlayerFound()
    {
        inputActive = true;
    }

    private void PlayerLost()
    {
        inputActive = false;
    }

    private Dictionary<OVRInput.Controller, GameObject> CreateControllerSets()
    {
        Dictionary<OVRInput.Controller, GameObject> newSets = new Dictionary<OVRInput.Controller, GameObject>()
        {
            { OVRInput.Controller.LTrackedRemote, leftAnchor },
            { OVRInput.Controller.RTrackedRemote, rightAnchor },
            { OVRInput.Controller.Touchpad, headAnchor }
        };

        return newSets;
    }

}
