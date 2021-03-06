using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlModule : MonoBehaviour
{
    [Header("Module Stats")]
    public float InputMultiplier = 1;

    [Header("GeneralStats")]
    public Transform MainTransform;
    public Rigidbody Rigidbody;
    public float currentInputValue = 0f;
    public bool OnSlot = false;
    public Slot linkedSlot = null;

    [Header("Feedback Stats")]
    public MeshRenderer InputFeedback;
    public Material GreenLight;
    public Material RedLight;
    public FMODUnity.StudioEventEmitter ActivateSound;
    public FMODUnity.StudioEventEmitter DeactivateSound;

    public virtual float InputValue()
    {
        return currentInputValue;
    }

    public virtual void ChangeInputValue(float _inputValue)
    {
        currentInputValue = _inputValue;
    }

    public virtual void ActivateFunction()
    {

    }

    public virtual void DeactivateFunction()
    {

    }
}
