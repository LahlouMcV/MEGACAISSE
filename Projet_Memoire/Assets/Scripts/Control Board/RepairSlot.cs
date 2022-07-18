using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairSlot : MonoBehaviour
{
    [SerializeField] VehicleManager _VehicleManager;
    public ControlModule ConnectedModule;
    public MeshRenderer meshRender;
    public float currentInputValue = 0f;
    IEnumerator corout;

    private void Start()
    {
        corout = SacrificeModule();
    }

    public void PlugModule(ControlModule module)
    {
        module.MainTransform.position = this.transform.position; //+ (this.transform.up * 0.1f);
        module.MainTransform.rotation = this.transform.rotation;
        ConnectedModule = module;
        ConnectedModule.OnSlot = true;
        //module.linkedSlot = this;
        meshRender.materials[1].DOFloat(1, "_LightOn", 0.25f);
        StartCoroutine(corout);
        
    }

    public void RemoveModule()
    {
        ConnectedModule.OnSlot = false;
        ConnectedModule.linkedSlot = null;
        ConnectedModule = null;
        currentInputValue = 0f;
        meshRender.materials[1].DOFloat(0, "_LightOn", 0.25f);
        StopCoroutine(corout);
    }

    IEnumerator SacrificeModule()
    {
        Debug.Log("COROUTINE");
        for (int i = 0; i < 5; i++)
        {
            meshRender.materials[1].DOFloat(0, "_LightOn", 0.1f);
            yield return new WaitForSeconds(0.1f);
            meshRender.materials[1].DOFloat(1, "_LightOn", 0.1f);
            yield return new WaitForSeconds(0.1f);
        }
        meshRender.materials[1].SetColor("_Color", Color.red);
        for (int i = 0; i < 5; i++)
        {
            meshRender.materials[1].DOFloat(0, "_LightOn", 0.05f);
            yield return new WaitForSeconds(0.05f);
            meshRender.materials[1].DOFloat(1, "_LightOn", 0.05f);
            yield return new WaitForSeconds(0.05f);
        }
        Destroy(ConnectedModule);
        ConnectedModule = null;
        currentInputValue = 0f;
        meshRender.materials[1].SetFloat("_LightOn", 0);
        meshRender.materials[1].SetColor("_Color", Color.cyan);
        _VehicleManager.MainHealthPoints = 100;
        _VehicleManager.LeftSideHealth = 25;
        _VehicleManager.RightSideHealth = 25;
        _VehicleManager.FrontSideHealth = 25;
        _VehicleManager.BackSideHealth = 25;
    }
}
