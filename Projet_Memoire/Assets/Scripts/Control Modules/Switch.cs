using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : ControlModule
{
    public bool on = false;
    public override void ActivateFunction()
    {
        base.ActivateFunction();
        if(on)
        {
            ChangeInputValue(0f);
            on = false;
        }
        else
        {
            ChangeInputValue(1f);
            on = true;
        }
    }
}
