using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraLook : MonoBehaviour
{
    [Header("Stats")]
    [Range(0,1)]
    [SerializeField] float MouseSensitivity = 1;
    [Header("Refs")]
    [SerializeField] PlayerManager _PlayerManager;
    [SerializeField] Transform CameraPos;
    
    // Update is called once per frame
    void LateUpdate()
    {

        this.transform.position = CameraPos.position;
        this.transform.rotation = CameraPos.rotation;
        if(_PlayerManager.currentInteractionState == PlayerManager.PlayerInteractionState.Movement)
        {
            CameraPos.transform.Rotate(-Mouse.current.delta.ReadValue().y * MouseSensitivity, 0, 0, Space.Self);
            CameraPos.transform.Rotate(0, Mouse.current.delta.ReadValue().x * MouseSensitivity, 0, Space.World);
            float xClamp = CameraPos.transform.localEulerAngles.x;
            xClamp = Mathf.Clamp(xClamp, -90, 90);
            //Camera.main.transform.localRotation = Quaternion.Euler(xClamp, Camera.main.transform.localRotation.eulerAngles.y, 0) ;
        }
    }
}
