using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Slot : MonoBehaviour
{
    public ControlModule ConnectedModule;
    public MeshRenderer meshRender;
    public float currentInputValue = 0f;

    public void PlugModule(ControlModule module)
    {
        module.MainTransform.position = this.transform.position; //+ (this.transform.up * 0.1f);
        module.MainTransform.rotation = this.transform.rotation;
        ConnectedModule = module;
        ConnectedModule.OnSlot = true;
        module.linkedSlot = this;
        meshRender.materials[1].DOFloat(1, "_LightOn", 0.25f);
    }

    public void RemoveModule()
    {
        ConnectedModule.OnSlot = false;
        ConnectedModule.linkedSlot = null;
        ConnectedModule = null;
        currentInputValue = 0f;
        meshRender.materials[1].DOFloat(0, "_LightOn", 0.25f);
    }

    private void Update()
    {
        if (ConnectedModule != null)
        {
            currentInputValue = ConnectedModule.InputValue();
        }
    }
}
