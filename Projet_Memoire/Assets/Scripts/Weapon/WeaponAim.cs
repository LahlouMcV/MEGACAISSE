using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAim : MonoBehaviour
{
    [SerializeField] VehicleManager _VehicleManager;
    [SerializeField] Transform _WeaponCamera;

    public void AimUpDown(float input)
    {
        if (input != 0) Debug.Log("Aiming like a king");

        _WeaponCamera.Rotate(input * _VehicleManager._VehicleStats.AimSensitivity, 0, 0, Space.Self);
        if (_WeaponCamera.localEulerAngles.x > 45 && _WeaponCamera.localEulerAngles.x < 310)
        {
            _WeaponCamera.localEulerAngles = new Vector3(44.95f, _WeaponCamera.localEulerAngles.y);
        }
        else if (_WeaponCamera.localEulerAngles.x > 50 && _WeaponCamera.localEulerAngles.x < 315)
        {
            _WeaponCamera.localEulerAngles = new Vector3(314.95f, _WeaponCamera.localEulerAngles.y);
        }
    }

    public void AimLeftRight(float input)
    {
        if (input != 0) Debug.Log("Aiming like a king");

        _WeaponCamera.Rotate(0, input * _VehicleManager._VehicleStats.AimSensitivity, 0, Space.World);
    }

}
