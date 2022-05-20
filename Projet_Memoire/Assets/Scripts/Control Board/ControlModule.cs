using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ControlModule : MonoBehaviour
{
    public bool OnSlot = false;
    public bool Active = false;
    public virtual float InputValue()
    {
        float f = 0f;
        return f;
    }

}
