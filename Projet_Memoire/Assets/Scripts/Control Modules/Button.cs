using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : ControlModule
{
    public override void ActivateFunction()
    {
        base.ActivateFunction();
        ChangeInputValue(1f);
    }

    public override void DeactivateFunction()
    {
        base.DeactivateFunction();
        ChangeInputValue(0f);
    }
}
