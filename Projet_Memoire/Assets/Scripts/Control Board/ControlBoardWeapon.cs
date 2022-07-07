using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBoardWeapon : MonoBehaviour
{
    [SerializeField] WeaponManager _WeaponManager;

    public WeaponSlotGroupe _WeaponSlotGroupe;

    private void LateUpdate()
    {
        //Aim Functions
        _WeaponManager._WeaponAim.AimUpDown(-_WeaponSlotGroupe.UpAim.currentInputValue);

        _WeaponManager._WeaponAim.AimUpDown(_WeaponSlotGroupe.DownAim.currentInputValue);

        _WeaponManager._WeaponAim.AimLeftRight(_WeaponSlotGroupe.RightAim.currentInputValue);

        _WeaponManager._WeaponAim.AimLeftRight(-_WeaponSlotGroupe.LeftAim.currentInputValue);

        //Shoot Functions
        _WeaponManager._WeaponShoot.ShootWeapon(_WeaponSlotGroupe.Shoot.currentInputValue);

        //Camera Position
        if (_WeaponSlotGroupe.CameraPos1.currentInputValue > 0) _WeaponManager._WeaponAim.ChangeCameraPosition(0);
        if (_WeaponSlotGroupe.CameraPos2.currentInputValue > 0) _WeaponManager._WeaponAim.ChangeCameraPosition(1);
        if (_WeaponSlotGroupe.CameraPos3.currentInputValue > 0) _WeaponManager._WeaponAim.ChangeCameraPosition(2);
    }
}
