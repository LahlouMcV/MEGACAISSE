using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGrabAndDrop : MonoBehaviour
{
    public bool Active = true;
    public bool ObjectGrabbed = false;

    private InputAction LeftClick;
    private RaycastHit hit;

    private Rigidbody Interactable;
    private Vector3 CursorPosition;

    private void Awake()
    {
        LeftClick = new InputAction(binding: "<Mouse>/leftButton");
        LeftClick.performed += _ => LeftMouseButtonClicked();
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
        if(Active)
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.GetMask("Interactable"));
            if (hit.collider != null && hit.collider.CompareTag("Interactable"))
            {
                Debug.Log("I hit something");
                Interactable = hit.collider.GetComponent<Rigidbody>();
            }

            CursorPosition = Camera.main.ScreenToWorldPoint((Vector3)Mouse.current.position.ReadValue() + (Vector3.forward * 3));
            
            if (ObjectGrabbed)
            {
                Interactable.isKinematic = true;
                Interactable.MovePosition(Vector3.Lerp(Interactable.transform.position, CursorPosition, 0.1f));
            }
        }
    }

    private void LeftMouseButtonClicked()
    {
        Debug.Log("Try to grab");
        if(Interactable != null && ObjectGrabbed == false)
        {
            ObjectGrabbed = true;
        }
        else if(ObjectGrabbed == true)
        {
            ObjectGrabbed = false;
            Interactable.isKinematic = false;
            Interactable = null;
        }
    }
}
