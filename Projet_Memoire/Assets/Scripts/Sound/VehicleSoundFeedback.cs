using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSoundFeedback : MonoBehaviour
{
    [SerializeField] FMODUnity.StudioEventEmitter motor;
    [SerializeField] FMODUnity.StudioEventEmitter LeftWallHit;
    [SerializeField] FMODUnity.StudioEventEmitter RightWallHit;
    [SerializeField] FMODUnity.StudioEventEmitter FrontWallHit;
    [SerializeField] FMODUnity.StudioEventEmitter BackWallHit;

    public void SetMotorParam(float amount)
    {
        motor.SetParameter(motor.Params[0].ID, amount);
    }

    public void HitWall(VehicleCollisionManager.HitBoxSide side)
    {
        switch (side)
        {
            case VehicleCollisionManager.HitBoxSide.Left:
                break;
            case VehicleCollisionManager.HitBoxSide.Right:
                break;
            case VehicleCollisionManager.HitBoxSide.Forward:
                break;
            case VehicleCollisionManager.HitBoxSide.Back:
                break;
        }
    }
}
