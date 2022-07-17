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
    [SerializeField] private ControlModule Interactable;
    private Vector3 CursorPosition;
    private Slot HighlightedSlot;
    public ControlModule module;
    [Header("Reference")]
    [SerializeField] private Transform ModuleHolder;
    [SerializeField] private Transform Vehicle;

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
        _ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        //If in normal FPS controls mode
        if (Active)
        {
            //Launch a raycast to check the interactable layer
            Physics.Raycast(_ray, out hit, Mathf.Infinity, LayerMask.GetMask("Interactable"));


            //If there's a collider than it is possible to grab the object
            if (hit.collider != null && (hit.collider.CompareTag("Interactable") || hit.collider.CompareTag("Controller_Module")) && ObjectGrabbed == false)
            {
                Interactable = hit.collider.GetComponentInChildren<ControlModule>();
            }
            else if (hit.collider == null && ObjectGrabbed == false)
            {
                Interactable = null;
            }

            //Launch a raycast to check the slot layer
            Physics.Raycast(_ray, out slotHit, Mathf.Infinity, LayerMask.GetMask("Slot"));

            //If there's a collider than it is possible to drop the object onto the slot
            if (slotHit.collider != null && slotHit.collider.CompareTag("Slot"))
            {
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
                Interactable.MainTransform.parent = ModuleHolder;
                Interactable.MainTransform.localPosition = Vector3.zero;
                Interactable.MainTransform.localRotation = Quaternion.identity;
            }
        }
        else
        {
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
            if (Interactable != null && ObjectGrabbed == false)
            {
                if (Interactable.OnSlot)
                {
                    Interactable.linkedSlot.RemoveModule();
                }
                ObjectGrabbed = true;
                Interactable.Rigidbody.isKinematic = true;
            }
            else if (ObjectGrabbed == true && HighlightedSlot == null)
            {
                ObjectGrabbed = false;
                Interactable.MainTransform.parent = Vehicle;
                Interactable.Rigidbody.isKinematic = false;
                Interactable = null;
            }
            else if (ObjectGrabbed == true && HighlightedSlot != null && HighlightedSlot.ConnectedModule == null)
            {
                ObjectGrabbed = false;
                Interactable.MainTransform.parent = Vehicle;
                HighlightedSlot.PlugModule(Interactable);
                Interactable = null;
            }
            else if (ObjectGrabbed == false && HighlightedSlot != null && Interactable != null)
            {
                ObjectGrabbed = true;
                Interactable.Rigidbody.isKinematic = true;
                Interactable.linkedSlot.RemoveModule();
            }
        }
        else
        {
            if(module != null)
            {
                //Debug.Break();
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

    void OnGUI()
    {
        //GUI.skin.label.fontSize = 72;
        //GUILayout.Label("Current mouse position : " + Mouse.current.position.ReadValue());
    }

    Ray _ray;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(_ray.origin, 0.5f);
        Gizmos.DrawLine(_ray.origin, _ray.origin + _ray.direction * 100);
    }


}
