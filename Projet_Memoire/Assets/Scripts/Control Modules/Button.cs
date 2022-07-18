using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Button : ControlModule
{
    public MeshRenderer meshFeedback;
    [SerializeField] GameObject textfield;

    private void Start()
    {
        textfield.GetComponent<TMP_Text>().text = (InputMultiplier * 100).ToString() + "%";
    }

    public override void ActivateFunction()
    {
        base.ActivateFunction();
        ChangeInputValue(1f * InputMultiplier);
        meshFeedback.materials[1].DOFloat(1, "_LightOn", 0.05f);
        meshFeedback.materials[1].SetColor("_Color", Color.green);
        textfield.GetComponent<TMP_Text>().text = (currentInputValue * 100).ToString() + "%";
        ActivateSound.Play();
        this.transform.localPosition = new Vector3(0.0f, -0.013f, -0.1f);
    }

    public override void DeactivateFunction()
    {
        base.DeactivateFunction();
        ChangeInputValue(0f);
        ActivateSound.Play();
        meshFeedback.materials[1].DOFloat(0, "_LightOn", 0.05f);
        textfield.GetComponent<TMP_Text>().text = (currentInputValue * 100).ToString() + "%";
        this.transform.localPosition = new Vector3(0.0f, 0f, -0.1f);
    }
}
