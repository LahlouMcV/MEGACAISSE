using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlModule : MonoBehaviour
{
    public Transform MainTransform;
    public float currentInputValue = 0f;
    public bool OnSlot = false;

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
