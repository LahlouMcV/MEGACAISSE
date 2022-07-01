using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : ControlModule
{
    [Header("Slingshot Stats")]
    [SerializeField] int Steps = 4;
    [SerializeField] Vector3 StartPosition;
    [SerializeField] Vector3 EndPosition;
    [SerializeField] GameObject StartPos;
    [SerializeField] GameObject EndPos;

    private bool MovingSlider = false;
    private int step = 0;
    private RaycastHit hit;
    //private Vector3 startMousePos;
    private Vector3 startPos;

    private void FixedUpdate()
    {
        if (MovingSlider)
        {
            Ray _rayForSlot = Camera.main.ScreenPointToRay(UnityEngine.InputSystem.Mouse.current.position.ReadValue());
            Physics.Raycast(_rayForSlot, out hit, Mathf.Infinity);
            if (hit.collider != null)
            {
                EndPos.transform.position = hit.point;
                this.transform.position = EndPos.transform.position;
                Debug.Log(EndPos.transform.position);
                float x = this.transform.localPosition.x;
                float y = this.transform.localPosition.y;
                float z = this.transform.localPosition.z;
                
                float currentEndPosition = (EndPosition.z - StartPosition.z) * (float)((float)step/(float)Steps);

                this.transform.localPosition = new Vector3(Mathf.Clamp(x, StartPosition.x, EndPosition.x),
                      Mathf.Clamp(y, StartPosition.y, EndPosition.y),
                      Mathf.Clamp(z, currentEndPosition, StartPosition.z));
                Debug.Log(this.transform.localPosition);
                if (currentInputValue == 0) InputFeedback.material = RedLight;
                else if (currentInputValue >= 1) InputFeedback.material = GreenLight;
            }
        }
    }

    public override void ActivateFunction()
    {
        step = 0;
        base.ActivateFunction();
        Debug.Log("Pulling Slingshot");
        MovingSlider = true;
        startPos = this.transform.localPosition;
        Ray _rayForSlot = Camera.main.ScreenPointToRay(UnityEngine.InputSystem.Mouse.current.position.ReadValue());
        Physics.Raycast(_rayForSlot, out hit, Mathf.Infinity, LayerMask.GetMask("Interactable"));
        if (hit.collider != null)
        {
            StartPos.transform.position = hit.point;
        }
        step++;
        Invoke("WaitToChangeStep", 0.75f);
    }

    public override void DeactivateFunction()
    {
        base.DeactivateFunction();
        MovingSlider = false;
        float z = this.transform.localPosition.z;
        Mathf.Clamp(z, StartPosition.z, EndPosition.z);
        float inputValue = ((z - StartPosition.z) / (EndPosition.z - StartPosition.z)) * InputMultiplier;
        this.ChangeInputValue(Mathf.Clamp(inputValue, 0, 1 * InputMultiplier));
        InputFeedback.material = GreenLight;
        StartCoroutine(GoBackToStart());
        Invoke("ChangeFeedbackBack", 0.5f);
    }

    private void WaitToChangeStep()
    {
        step++;
        Debug.Log("Current step is " + step);
        if(step < Steps)
        {
            Invoke("WaitToChangeStep", 0.5f + 0.25f * step);
        }
    }

    private void ChangeFeedbackBack()
    {
        InputFeedback.material = RedLight;
        ChangeInputValue(0);
    }

    IEnumerator GoBackToStart()
    {
        while(true)
        {
            this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, StartPosition, 0.2f);
            if(this.transform.localPosition == StartPosition)
            {
                StopAllCoroutines();
                break;
            }
            yield return null;
        }
    }
}
