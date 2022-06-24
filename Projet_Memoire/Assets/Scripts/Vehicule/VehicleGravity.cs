using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleGravity : MonoBehaviour
{
    [SerializeField] private VehicleManager _VehicleManager;
    [SerializeField] private Transform _Bumper;
    public float currentForce;

    private RaycastHit GroundHit;

    void FixedUpdate()
    {
        
        Ray ray = new Ray(_Bumper.position, -this.transform.up);
        Physics.Raycast(ray,out GroundHit, Mathf.Infinity, LayerMask.GetMask("Ground"));
        if (GroundHit.collider != null && GroundHit.collider.CompareTag("Ground") && 
            Vector3.Distance(_Bumper.position, GroundHit.point) <= _VehicleManager._VehicleStats.FloatHeight)
        {
            RaiseVehicle();
        }
        else if(GroundHit.collider != null && 
            Vector3.Distance(_Bumper.position, GroundHit.point) >=  _VehicleManager._VehicleStats.FloatHeight + 5f)
        {
            ApplyGravity();
        }
        else
        {
            currentForce = Mathf.Lerp(currentForce, 0, 0.1f);
        }

        if(GroundHit.collider != null)
        {
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation,
                Quaternion.Euler(new Vector3(GroundHit.transform.rotation.eulerAngles.x, this.transform.rotation.eulerAngles.y, this.transform.rotation.eulerAngles.z)),
                0.1f);
        }

        Mathf.Clamp(currentForce, -_VehicleManager._VehicleStats.TerminalVelocity, _VehicleManager._VehicleStats.TerminalVelocity);
        this.transform.position += (currentForce * this.transform.up * Time.deltaTime);
    }

    private void RaiseVehicle()
    {
        currentForce += _VehicleManager._VehicleStats.FloatForce * Time.deltaTime;
    }

    private void ApplyGravity()
    {
        currentForce -= _VehicleManager._VehicleStats.Gravity * Time.deltaTime;
    }
}
