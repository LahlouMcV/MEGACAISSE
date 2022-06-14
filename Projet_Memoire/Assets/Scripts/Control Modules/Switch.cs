using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : ControlModule
{
    public bool on = false;

    private void Start()
    {
        InputFeedback.material = RedLight;
        this.transform.localRotation = Quaternion.Euler(-10, 0, 0);
    }

    public override void ActivateFunction()
    {
        base.ActivateFunction();
        if(on)
        {
            ChangeInputValue(0f);
            on = false;
            InputFeedback.material = RedLight;
            this.transform.localRotation = Quaternion.Euler(-10, 0, 0);
        }
        else
        {
            ChangeInputValue(1f);
            on = true;
            InputFeedback.material = GreenLight;
            this.transform.localRotation = Quaternion.Euler(10, 0, 0);
        }
    }
}
