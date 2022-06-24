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
    [SerializeField] FMODUnity.StudioEventEmitter GroundHit;

    public void SetMotorParam(float amount)
    {
        motor.SetParameter(motor.Params[0].ID, amount);
    }

    public void HitWall(VehicleCollisionManager.HitBoxSide side)
    {
        switch (side)
        {
            case VehicleCollisionManager.HitBoxSide.Left:
                LeftWallHit.Play();
                break;
            case VehicleCollisionManager.HitBoxSide.Right:
                RightWallHit.Play();
                break;
            case VehicleCollisionManager.HitBoxSide.Forward:
                FrontWallHit.Play();
                break;
            case VehicleCollisionManager.HitBoxSide.Back:
                BackWallHit.Play();
                break;
        }
    }

    public void HitGround()
    {
        //GroundHit.Play();
    }
}
