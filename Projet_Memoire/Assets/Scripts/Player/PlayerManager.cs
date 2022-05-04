using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public enum PlayerInteractionState { Movement, Interaction};

    [Header("current Stats")]
    public PlayerInteractionState currentInteractionState;

    [Header("ReferenceScripts")]
    [SerializeField] private StarterAssets.FirstPersonController firstPersonController;
    [SerializeField] private UI_InteractionFeedbackManager FeedbackManager;
    [SerializeField] private PlayerGrabAndDrop grabAndDrop;

    private InputAction RightClick;
    private InputAction LeftClick;
    private bool RightClickOnce = false;

    //Creation of input actions for the changing of modes
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        RightClick = new InputAction(binding: "<Mouse>/rightButton");
        RightClick.performed += _ => ChangeInteractionState();
    }

    //Enabling of input Action
    private void OnEnable()
    {
        RightClick.Enable();
    }

    //Disabling of Input Action
    private void OnDisable()
    {
        RightClick.Disable();
    }

    //Function that changes the player Interaction state
    private void ChangeInteractionState()
    {
        Debug.Log("RightClick");
        if(currentInteractionState == PlayerInteractionState.Movement)
        {
            currentInteractionState = PlayerInteractionState.Interaction;
            firstPersonController.Active = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            FeedbackManager.LaunchInteractionMode();
            grabAndDrop.Active = false;
        }
        else
        {
            currentInteractionState = PlayerInteractionState.Movement;
            firstPersonController.Active = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            FeedbackManager.StopInteractionMode();
            grabAndDrop.Active = true;
        }
        
    }

}
