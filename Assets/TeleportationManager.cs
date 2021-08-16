using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportationManager : MonoBehaviour
{
    [SerializeField] private InputActionAsset actionAsset;
    [SerializeField] private XRRayInteractor rayInteractor;

    private InputAction _thumbstick;
    private bool _isActive;

    // Start is called before the first frame update
    void Start()
    {

        rayInteractor.enabled = false;

        var activate = actionAsset.FindActionMap("XRI LeftHand").FindAction("Teleport Mode Activate");
        activate.Enable();
        activate.performed += OnTeleportActivate;

        var cancel = actionAsset.FindActionMap("XRI LeftHand").FindAction("Teleport Mode Cancel");
        cancel.Enable();
        cancel.performed += OnTeleportCancel;


        var _thumbstick = actionAsset.FindActionMap("XRI LeftHand").FindAction("Move");
        _thumbstick.Enable();
    } 

    // Update is called once per frame
    void Update()
    {
        if (!_isActive)
            return;
    }

    private void OnTeleportActivate(InputAction.CallbackContext context)
    {
        rayInteractor.enabled = true;

    }

    private void OnTeleportCancel(InputAction.CallbackContext context)
    {
        rayInteractor.enabled = false;

    }
}
