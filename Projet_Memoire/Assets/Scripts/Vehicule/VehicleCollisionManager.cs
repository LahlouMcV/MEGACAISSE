using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VehicleCollisionManager : MonoBehaviour
{
    public enum HitBoxSide { Up, Down, Left, Right, Forward, Back};
    [SerializeField] private VehicleManager _VehicleManager;
    [Header("Events")]
    public UnityEvent OnCollidedWithCenter;
    public UnityEvent OnCollidedWithLeft;
    public UnityEvent OnCollidedWithRight;
    public UnityEvent OnCollidedWithFront;
    public UnityEvent OnCollidedWithBack;

    bool HitTimer = false;

    public void CollidedWithWall(HitBoxSide side, Transform wall)
    {
        if (HitTimer == false)
        {
            HitTimer = true;
            Invoke("ChangeHitTimer", 0.1f);
            Vector3 aimPosition = this.transform.position;
            Quaternion aimRotation = this.transform.rotation;
            _VehicleManager.HurtSide(_VehicleManager._VehicleStats.DamageWhenWallCollision, side);
            _VehicleManager._VehicleSoundFeedback.HitWall(side);
            switch (side)
            {
                case HitBoxSide.Up:
                    break;
                case HitBoxSide.Down:
                    break;
                case HitBoxSide.Left:
                    aimPosition = this.transform.position + this.transform.right * 10;
                    aimRotation = this.transform.rotation * Quaternion.AngleAxis(30, this.transform.up);
                    _VehicleManager._VehicleMovement.currentSpeed -= 40;
                    OnCollidedWithLeft.Invoke();
                    break;
                case HitBoxSide.Right:
                    aimPosition = this.transform.position - this.transform.right * 10;
                    aimRotation = this.transform.rotation * Quaternion.AngleAxis(-30, this.transform.up);
                    _VehicleManager._VehicleMovement.currentSpeed -= 40;
                    OnCollidedWithRight.Invoke();
                    break;
                case HitBoxSide.Forward:
                    RaycastHit hit;
                    Ray ray = new Ray(this.transform.position, this.transform.forward);
                    OnCollidedWithFront.Invoke();
                    if (Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.GetMask("Ground")))
                    {
                        Debug.Log(hit.normal);
                        if (hit.collider != null && Vector3.Angle(this.transform.forward, -hit.normal) <= 30)
                        {
                            Debug.Log("Case 1");
                            _VehicleManager._VehicleMovement.currentSpeed = -40;
                            _VehicleManager._VehicleMovement.DirectionVector = this.transform.forward;
                            aimPosition = this.transform.position - this.transform.forward * 2;
                            aimRotation = this.transform.rotation;
                        }
                    }
                    break;
                case HitBoxSide.Back:
                    OnCollidedWithBack.Invoke();
                    RaycastHit BackHit = new RaycastHit();
                    Ray BackRay = new Ray(this.transform.position, -this.transform.forward);
                    if (Physics.Raycast(BackRay, out BackHit, Mathf.Infinity, LayerMask.GetMask("Ground")))
                    {
                        Debug.Log(BackHit.normal);
                        if (BackHit.collider != null && Vector3.Angle(this.transform.forward, -BackHit.normal) <= 30)
                        {
                            Debug.Log("Case 1");
                            _VehicleManager._VehicleMovement.currentSpeed = 40;
                            _VehicleManager._VehicleMovement.DirectionVector = this.transform.forward;
                            aimPosition = this.transform.position - this.transform.forward * 2;
                            aimPosition = new Vector3(aimPosition.x, 5, aimPosition.z);
                            aimRotation = this.transform.rotation;
                        }
                    }
                    break;
            }
            _VehicleManager._VehicleMovement.currentSpeed = Mathf.Clamp(_VehicleManager._VehicleMovement.currentSpeed, 0, 150);
            StartCoroutine(MoveVehicle(aimRotation, aimPosition));
            Invoke("StopTheCoroutines", 0.1f);
        }
    }

    public void CollidedWithObstacle(HitBoxSide side, Transform obstacle)
    {
        Debug.Log("Obstacle hit " + side + " side");
        Obstacle hitObstacle = obstacle.GetComponent<Obstacle>();
        _VehicleManager.HurtSide(hitObstacle.Damage, side);
        _VehicleManager._VehicleSoundFeedback.HitObstacle(side);
        switch (side)
        {
            case HitBoxSide.Up:
                break;
            case HitBoxSide.Down:
                break;
            case HitBoxSide.Left:
                OnCollidedWithLeft.Invoke();
                break;
            case HitBoxSide.Right:
                OnCollidedWithRight.Invoke();
                break;
            case HitBoxSide.Forward:
                OnCollidedWithFront.Invoke();
                break;
            case HitBoxSide.Back:
                OnCollidedWithBack.Invoke();
                break;
        }
        Destroy(obstacle.gameObject);
    }

    public void CollidedWithGround(HitBoxSide side)
    {
        Debug.Log("Hit Ground");
        switch (side)
        {
            case HitBoxSide.Up:
                break;
            case HitBoxSide.Down:
                this.transform.position += this.transform.up * 2;
                _VehicleManager._VehicleGravity.currentForce = 0;
                _VehicleManager.HurtAllSides(_VehicleManager._VehicleStats.FallDamage);
                _VehicleManager._VehicleSoundFeedback.HitGround();
                break;
            case HitBoxSide.Left:
                break;
            case HitBoxSide.Right:
                break;
            case HitBoxSide.Forward:
                break;
            case HitBoxSide.Back:
                break;
        }
    }

    public void StopTheCoroutines()
    {
        StopAllCoroutines();
    }

    IEnumerator MoveVehicle(Quaternion rotation, Vector3 position)
    {
        while(true)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, position, 0.1f);
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, rotation, 0.1f);
            if (this.transform.position == position && this.transform.rotation == rotation) StopAllCoroutines();
            yield return null;
        }
    }

    public void CollideWithCenter()
    {
        OnCollidedWithCenter.Invoke();
    }

    public void ChangeHitTimer()
    {
        HitTimer = false;
    }
}
