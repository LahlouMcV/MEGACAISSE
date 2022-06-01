using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBoard : MonoBehaviour
{
    public VehicleManager _VehicleManager;

    public SlotGroupe _SlotGroupe;

    private void LateUpdate()
    {
        //Movement functions
        _VehicleManager._VehicleMovement.Accelerate(_SlotGroupe.Accelerate.currentInputValue);

        _VehicleManager._VehicleMovement.Break(_SlotGroupe.Break.currentInputValue);

        _VehicleManager._VehicleMovement.Rotate(_SlotGroupe.TurnRight.currentInputValue);

        _VehicleManager._VehicleMovement.Rotate(-_SlotGroupe.TurnLeft.currentInputValue);

        _VehicleManager._VehicleMovement.Straff(_SlotGroupe.StraffRight.currentInputValue);

        _VehicleManager._VehicleMovement.Straff(-_SlotGroupe.StraffLeft.currentInputValue);
    }
}
