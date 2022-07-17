using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : ControlModule
{
    public override void ActivateFunction()
    {
        base.ActivateFunction();
        ChangeInputValue(1f * InputMultiplier);
        InputFeedback.material = GreenLight;
        ActivateSound.Play();
        this.transform.localPosition = new Vector3(0.0f, 0.1f, 0.0f);
    }

    public override void DeactivateFunction()
    {
        base.DeactivateFunction();
        ChangeInputValue(0f);
        ActivateSound.Play();
        InputFeedback.material = RedLight;
        this.transform.localPosition = new Vector3(0.0f, 1.04f, 0.0f);
    }
}
