using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Switch : ControlModule
{
    public bool on = false;
    public MeshRenderer meshFeedback;
    [SerializeField] GameObject textfield;

    private void Start()
    {
        InputFeedback.material = RedLight;
        this.transform.localRotation = Quaternion.Euler(50, 0, 0);
        meshFeedback.materials[1].SetFloat("_LightOn", 0);
        meshFeedback.materials[1].SetColor("_Color", Color.green);
        textfield.GetComponent<TMP_Text>().text = (InputMultiplier*100).ToString() + "%";
    }

    public override void ActivateFunction()
    {
        base.ActivateFunction();
        if(on)
        {
            ChangeInputValue(0f);
            on = false;
            InputFeedback.material = RedLight;
            meshFeedback.materials[1].SetFloat("_LightOn", 0);
            textfield.GetComponent<TMP_Text>().color = Color.grey;
            ActivateSound.Play();
            this.transform.localRotation = Quaternion.Euler(50, 0, 0);
        }
        else
        {
            ChangeInputValue(1f * InputMultiplier);
            on = true;
            InputFeedback.material = GreenLight;
            meshFeedback.materials[1].SetFloat("_LightOn", 1);
            textfield.GetComponent<TMP_Text>().color = Color.green;
            ActivateSound.Play();
            this.transform.localRotation = Quaternion.Euler(-50, 0, 0);
        }
    }
}
