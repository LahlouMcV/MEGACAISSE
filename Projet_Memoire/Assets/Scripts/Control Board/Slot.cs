using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public ControlModule ConnectedModule;

    public void PlugModule(ControlModule module)
    {
        module.transform.position = this.transform.position + (this.transform.up * 0.1f);
        module.transform.rotation = this.transform.rotation;
        ConnectedModule = module;
    }

    public void RemoveModule()
    {
        ConnectedModule = null;
    }
}
