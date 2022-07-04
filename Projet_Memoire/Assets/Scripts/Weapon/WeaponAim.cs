using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAim : MonoBehaviour
{
    [SerializeField] VehicleManager _VehicleManager;
    [SerializeField] Transform _WeaponCamera;

    public void AimUpDown(float input)
    {
        _WeaponCamera.Rotate(input * _VehicleManager._VehicleStats.AimSensitivity, 0, 0, Space.Self);
    }

    public void AimLeftRight(float input)
    {
        _WeaponCamera.Rotate(0, input * _VehicleManager._VehicleStats.AimSensitivity, 0, Space.World);
    }
}
