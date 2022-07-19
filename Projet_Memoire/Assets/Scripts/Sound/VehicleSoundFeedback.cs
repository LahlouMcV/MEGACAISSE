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
    [SerializeField] FMODUnity.StudioEventEmitter ObstacleLeftHit;
    [SerializeField] FMODUnity.StudioEventEmitter ObstacleRightHit;
    [SerializeField] FMODUnity.StudioEventEmitter ObstacleFrontHit;
    [SerializeField] FMODUnity.StudioEventEmitter ObstacleBackHit;

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

    public void HitObstacle(VehicleCollisionManager.HitBoxSide side)
    {
        switch (side)
        {
            case VehicleCollisionManager.HitBoxSide.Left:
                ObstacleLeftHit.Play();
                break;
            case VehicleCollisionManager.HitBoxSide.Right:
                ObstacleRightHit.Play();
                break;
            case VehicleCollisionManager.HitBoxSide.Forward:
                ObstacleFrontHit.Play();
                break;
            case VehicleCollisionManager.HitBoxSide.Back:
                ObstacleBackHit.Play();
                break;
        }
    }

    public void HitGround()
    {
        GroundHit.Play();
    }
}
