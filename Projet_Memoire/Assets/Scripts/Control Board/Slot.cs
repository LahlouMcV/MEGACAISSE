using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public ControlModule ConnectedModule;
    public float currentInputValue = 0f;

    public void PlugModule(ControlModule module)
    {
        module.MainTransform.position = this.transform.position + (this.transform.up * 0.1f);
        module.MainTransform.rotation = this.transform.rotation;
        ConnectedModule = module;
    }

    public void RemoveModule()
    {
        ConnectedModule = null;
    }

    private void Update()
    {
        if (ConnectedModule != null)
        {
            currentInputValue = ConnectedModule.InputValue();
        }
    }
}
