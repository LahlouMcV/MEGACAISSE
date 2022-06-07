using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleCollisionManager : MonoBehaviour
{
    public enum HitBoxSide { Up, Down, Left, Right, Forward, Back};
    [SerializeField] private VehicleManager _VehicleManager;

    public void CollidedWithWall(HitBoxSide side, Transform wall)
    {
        Vector3 aimPosition = Vector3.zero;
        Quaternion aimRotation = Quaternion.identity;
        Debug.Log("Hit Wall on " + side + "Side");
        switch (side)
        {
            case HitBoxSide.Up:
                break;
            case HitBoxSide.Down:
                break;
            case HitBoxSide.Left:
                aimPosition = this.transform.position + this.transform.right * 2;
                aimRotation = this.transform.rotation * Quaternion.AngleAxis(30, this.transform.up);
                break;
            case HitBoxSide.Right:
                aimPosition = this.transform.position - this.transform.right * 2;
                aimRotation = this.transform.rotation * Quaternion.AngleAxis(-30, this.transform.up);
                break;
            case HitBoxSide.Forward:
                break;
            case HitBoxSide.Back:
                break;
        }
        StartCoroutine(MoveVehicle(aimRotation, aimPosition));
        Invoke("StopTheCoroutines", 0.1f);
    }

    public void CollidedWithObstacle(HitBoxSide side)
    {

    }

    public void CollidedWithGround(HitBoxSide side)
    {
        switch (side)
        {
            case HitBoxSide.Up:
                break;
            case HitBoxSide.Down:
                this.transform.position += this.transform.up * 2;
                _VehicleManager._VehicleGravity.currentForce = 0;
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
}
