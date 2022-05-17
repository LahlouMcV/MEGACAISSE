using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TempVehicleInput : MonoBehaviour
{
    [Header("VehicleManager")]
    [SerializeField] VehicleMovement movement;

    private InputAction O;
    private InputAction L;
    private InputAction K;
    private InputAction M;
    private InputAction I;
    private InputAction P;

    private bool OPressed = false;
    private bool LPressed = false;
    private bool KPressed = false;
    private bool MPressed = false;
    private bool IPressed = false;
    private bool PPressed = false;

    private void Awake()
    {
        O = new InputAction (binding: "<Keyboard>/o");
        L = new InputAction (binding: "<Keyboard>/l");
        K = new InputAction (binding: "<Keyboard>/k");
        M = new InputAction (binding: "<Keyboard>/semicolon");
        I = new InputAction (binding: "<Keyboard>/i");
        P = new InputAction (binding: "<Leyboard>/p");

        O.performed += _ => PressO();
        L.performed += _ => PressL();
        K.performed += _ => PressK();
        M.performed += _ => PressM();

        O.canceled += _ => ReleaseO();
        L.canceled += _ => ReleaseL();
        K.canceled += _ => ReleaseK();
        M.canceled += _ => ReleaseM();
    }

    private void Update()
    {
        if(OPressed == false)
        {
            movement.Accelerate(0);
        }
    }

    private void OnEnable()
    {
        O.Enable();
        L.Enable();
        K.Enable();
        M.Enable();
    }

    private void OnDisable()
    {
        O.Disable();
        L.Disable();
        K.Disable();
        M.Disable();
    }

    private void PressO()
    {
        OPressed = true;
        StartCoroutine(OHeld());
    }

    private void ReleaseO()
    {
        OPressed = false;
        StopCoroutine(OHeld());
    }

    private void PressL()
    {
        LPressed = true;
        StartCoroutine(LHeld());
    }

    private void ReleaseL()
    {
        LPressed = false;
        StopCoroutine(LHeld());
    }

    private void PressK()
    {
        KPressed = true;
        StartCoroutine(KHeld());
    }

    private void ReleaseK()
    {
        KPressed = false;
        StopCoroutine(KHeld());
    }

    private void PressM()
    {
        Debug.Log("Pressed M");
        MPressed = true;
        StartCoroutine(MHeld());
    }
    
    private void ReleaseM()
    {
        MPressed = false;
        StopCoroutine(MHeld());
    }

    private void PressI()
    {

    }

    private void ReleaseI()
    {

    }

    IEnumerator OHeld()
    {
        while(OPressed)
        {
            movement.Accelerate(1);
            yield return null;
        }
    }

    IEnumerator KHeld()
    {
        while(KPressed)
        {
            movement.Rotate(-1);
            yield return null;
        }
    }

    IEnumerator LHeld()
    {
        while(LPressed)
        {
            movement.Break(1);
            yield return null;
        }
    }

    IEnumerator MHeld()
    {
        while (MPressed)
        {
            movement.Rotate(1);
            yield return null;
        }
    }

    IEnumerator IHeld()
    {
        while(IPressed)
        {
            yield return null;
        }
    }

    IEnumerator PHeld()
    {
        while (PPressed)
        {
            yield return null;
        }
    }
}
