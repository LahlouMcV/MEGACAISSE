using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponSlotGroupe
{
    [Header("Aiming Functions")]
    public Slot UpAim;
    public Slot DownAim;
    public Slot RightAim;
    public Slot LeftAim;

    [Header("Shooting Functions")]
    public Slot Shoot;

}
