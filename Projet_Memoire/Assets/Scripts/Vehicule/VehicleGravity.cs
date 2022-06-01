using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleGravity : MonoBehaviour
{
    [SerializeField] private VehicleManager _VehicleManager;
    private float currentForce;

    private RaycastHit GroundHit;

    void Update()
    {
        
        Ray ray = new Ray(this.transform.position, -this.transform.up);
        Physics.Raycast(ray,out GroundHit, Mathf.Infinity, LayerMask.GetMask("Ground"));
        if (GroundHit.collider != null && GroundHit.collider.CompareTag("Ground") && Vector3.Distance(this.transform.position, GroundHit.point) <= 5f)
        {
            RaiseVehicle();
        }
        else if(Vector3.Distance(this.transform.position, GroundHit.point) > 5f)
        {
            ApplyGravity();
        }

        /*this.transform.rotation = Quaternion.Lerp(this.transform.rotation, 
            Quaternion.Euler(new Vector3(GroundHit.transform.rotation.x, this.transform.rotation.y, this.transform.rotation.z)), 
            0.01f);*/
        this.transform.position += (currentForce * this.transform.up * Time.deltaTime);
    }

    private void RaiseVehicle()
    {
        currentForce += _VehicleManager._VehicleStats.Gravity * Time.deltaTime;
    }

    private void ApplyGravity()
    {
        currentForce -= _VehicleManager._VehicleStats.Gravity * Time.deltaTime;
    }
}
