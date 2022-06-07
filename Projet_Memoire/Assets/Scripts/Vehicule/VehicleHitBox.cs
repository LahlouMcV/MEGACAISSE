using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleHitBox : MonoBehaviour
{
    [SerializeField] private VehicleCollisionManager _VehicleCollisionManager;
    [SerializeField] private VehicleCollisionManager.HitBoxSide Side;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Obstacle"))
        {
            _VehicleCollisionManager.CollidedWithObstacle(this.Side);
        }
        else if(other.CompareTag("Wall"))
        {
            _VehicleCollisionManager.CollidedWithWall(this.Side, other.transform);
        }
        else if(other.CompareTag("Ground"))
        {
            _VehicleCollisionManager.CollidedWithGround(this.Side);
        }
    }
}
