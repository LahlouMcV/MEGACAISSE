using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlideModule : ControlModule
{
    [Header("Slider Stats")]
    [SerializeField] Vector3 StartPosition;
    [SerializeField] Vector3 EndPosition;
    [SerializeField] GameObject StartPos;
    [SerializeField] GameObject EndPos;
    [SerializeField] GameObject textfield;
    [SerializeField] GameObject Jauge;

    private bool MovingSlider = false;
    private RaycastHit hit;
    //private Vector3 startMousePos;
    private Vector3 startPos;

    private void Start()
    {
        textfield.GetComponent<TMP_Text>().text = Mathf.Round(InputMultiplier * 100).ToString() + "%";
    }

    private void FixedUpdate()
    {
        if(MovingSlider)
        {
            Ray _rayForSlot = Camera.main.ScreenPointToRay(UnityEngine.InputSystem.Mouse.current.position.ReadValue());
            Physics.Raycast(_rayForSlot, out hit, Mathf.Infinity);
            if(hit .collider != null)
            {
                EndPos.transform.position = hit.point;
                Vector3 moveVector = EndPos.transform.position - StartPos.transform.position;
                this.transform.position = EndPos.transform.position;
                float x = this.transform.localPosition.x;
                float y = this.transform.localPosition.y;
                float z = this.transform.localPosition.z;
                this.transform.localPosition = new Vector3(Mathf.Clamp(x, StartPosition.x, EndPosition.x), 
                      Mathf.Clamp(y, StartPosition.y, EndPosition.y),
                      Mathf.Clamp(z, StartPosition.z, EndPosition.z));
                float inputValue = ((z - StartPosition.z) / (EndPosition.z - StartPosition.z)) * InputMultiplier;
                this.ChangeInputValue(Mathf.Clamp(inputValue, 0,InputMultiplier));

                //coucou!
                Jauge.GetComponent<Image>().fillAmount = currentInputValue/ InputMultiplier;
                textfield.GetComponent<TMP_Text>().text = Mathf.Round(currentInputValue * 100).ToString() + "%";

                if (currentInputValue == 0) InputFeedback.material = RedLight;
                else if (currentInputValue >= 1) InputFeedback.material = GreenLight;
            }
        }
    }

    public override void ActivateFunction()
    {
        base.ActivateFunction();
        MovingSlider = true;
        ActivateSound.Play();
        startPos = this.transform.localPosition;
        Ray _rayForSlot = Camera.main.ScreenPointToRay(UnityEngine.InputSystem.Mouse.current.position.ReadValue());
        Physics.Raycast(_rayForSlot, out hit, Mathf.Infinity, LayerMask.GetMask("Interactable"));
        if (hit.collider != null)
        {
            StartPos.transform.position = hit.point;
        }
    }

    public override void DeactivateFunction()
    {
        base.DeactivateFunction();
        ActivateSound.Stop();
        MovingSlider = false;
    }
}
