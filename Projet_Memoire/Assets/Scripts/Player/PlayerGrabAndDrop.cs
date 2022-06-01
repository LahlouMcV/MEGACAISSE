using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGrabAndDrop : MonoBehaviour
{
    [Header("current Stats")]
    public bool Active = true;
    public bool ObjectGrabbed = false;

    [Header("Module Interaction Variables")]
    public RaycastHit ModuleInteractionHit;
    public RaycastHit OriginalModuleInteractionHit;

    //Grabbing Interactable object Stats
    private InputAction LeftClick;
    private RaycastHit hit;
    private RaycastHit slotHit;
    private Rigidbody Interactable;
    private Vector3 CursorPosition;
    private Slot HighlightedSlot;
    public ControlModule module;

    private bool LeftClickHeld = false;

    private void Awake()
    {
        LeftClick = new InputAction(binding: "<Mouse>/leftButton");
        LeftClick.performed += _ => LeftMouseButtonClicked();
        LeftClick.canceled += _ => LeftMouseButtonReleased();
        HighlightedSlot = null;
    }

    private void OnEnable()
    {
        LeftClick.Enable();
    }

    private void OnDisable()
    {
        LeftClick.Disable();
    }

    private void Update()
    {
        //If in normal FPS controls mode
        if(Active)
        {
            //Launch a raycast to check the interactable layer
            Ray _ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            Physics.Raycast(_ray, out hit, Mathf.Infinity, LayerMask.GetMask("Interactable"));


            //If there's a collider than it is possible to grab the object
            if (hit.collider != null && hit.collider.CompareTag("Interactable"))
            {
                Debug.Log("I hit something");
                Interactable = hit.collider.GetComponent<Rigidbody>();
            }
            else if (hit.collider == null && ObjectGrabbed == false)
            {
                Interactable = null;
            }

            //Launch a raycast to check the slot layer
            Ray _rayForSlot = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            Physics.Raycast(_rayForSlot, out slotHit, 3, LayerMask.GetMask("Slot"));

            //If there's a collider than it is possible to drop the object onto the slot
            if (slotHit.collider != null && slotHit.collider.CompareTag("Slot"))
            {
                Debug.Log("Found a slot");
                HighlightedSlot = slotHit.collider.GetComponent<Slot>();
            }
            else if (slotHit.collider == null)
            {
                HighlightedSlot = null;
            }

            //Calculating the cursor position in the world
            CursorPosition = Camera.main.ScreenToWorldPoint((Vector3)Mouse.current.position.ReadValue() + (Vector3.forward * 3));
            
            //If object is being held
            if (ObjectGrabbed)
            {
                //Launch raycast checking the ground to drop it and adjust position accordinginly
                RaycastHit _GroundHit;
                Physics.Raycast(_ray, out _GroundHit, 3, LayerMask.GetMask("Default"));

                //Change position 
                if (_GroundHit.collider != null && Vector3.Distance(this.transform.position, _GroundHit.point) < Vector3.Distance(this.transform.position, CursorPosition))
                {
                    CursorPosition = (_GroundHit.point - this.transform.position) + 
                        ((_GroundHit.point - this.transform.position).normalized * -0.25f);
                    CursorPosition += this.transform.position;
                }
                Interactable.MovePosition(Vector3.Lerp(Interactable.transform.position, CursorPosition, 0.1f));
            }
        }
        else
        {
            Ray _ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            Physics.Raycast(_ray, out ModuleInteractionHit, Mathf.Infinity, LayerMask.GetMask("Interactable"));
            if (ModuleInteractionHit.collider != null && ModuleInteractionHit.collider.CompareTag("Controller_Module"))
            {
                module = ModuleInteractionHit.collider.GetComponent<ControlModule>();
            }
            else if(ModuleInteractionHit.collider == null && LeftClickHeld == false)
            {
                module = null;
            }
        }
    }

    private void LeftMouseButtonClicked()
    {
        if(Active)
        {
            Debug.Log("Try to grab");
            if (Interactable != null && ObjectGrabbed == false)
            {
                ObjectGrabbed = true;
                Interactable.isKinematic = true;
            }
            else if (ObjectGrabbed == true && HighlightedSlot == null)
            {
                ObjectGrabbed = false;
                Interactable.isKinematic = false;
                Interactable = null;
            }
            else if (ObjectGrabbed == true && HighlightedSlot != null)
            {
                ObjectGrabbed = false;
                HighlightedSlot.PlugModule(Interactable.GetComponentInChildren<ControlModule>());
                Interactable = null;
            }
            else if (ObjectGrabbed == false && HighlightedSlot != null && Interactable != null)
            {
                ObjectGrabbed = true;
                HighlightedSlot.RemoveModule();
            }
        }
        else
        {
            if(module != null)
            {
                Debug.Log("I Click BUTTON!!!!!!!");
                Ray _ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
                Physics.Raycast(_ray, out ModuleInteractionHit, Mathf.Infinity, LayerMask.GetMask("Interactable"));
                if (ModuleInteractionHit.collider != null && ModuleInteractionHit.collider.CompareTag("Controller_Module"))
                {
                    OriginalModuleInteractionHit = ModuleInteractionHit;
                }
                module.SendMessage("ActivateFunction");
                StartCoroutine(LeftMouseButtonHeld());
                LeftClickHeld = true;
            }
        }
    }

    private void LeftMouseButtonReleased()
    {
        
        if (Active == false && module != null)
        {
            Debug.Log("I Deactivate BUTTON!!!!!!!");
            module.DeactivateFunction();
            StopCoroutine(LeftMouseButtonHeld());
            module = null;
        }
        LeftClickHeld = false;
    }

    IEnumerator LeftMouseButtonHeld()
    {
        while(true)
        {
            yield return null;
        }
    }


}