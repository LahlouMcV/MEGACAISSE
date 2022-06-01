using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraLook : MonoBehaviour
{
    [SerializeField] PlayerManager _PlayerManager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_PlayerManager.currentInteractionState == PlayerManager.PlayerInteractionState.Movement)
        {
            Camera.main.transform.Rotate(-Mouse.current.delta.ReadValue().y, 0, 0, Space.Self);
            Camera.main.transform.Rotate(0, Mouse.current.delta.ReadValue().x, 0, Space.World);
            float xClamp = Camera.main.transform.localEulerAngles.x;
            xClamp = Mathf.Clamp(xClamp, -90, 90);
            //Camera.main.transform.localRotation = Quaternion.Euler(xClamp, Camera.main.transform.localRotation.eulerAngles.y, 0) ;
        }
    }
}
