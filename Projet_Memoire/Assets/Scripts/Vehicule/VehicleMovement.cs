using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMovement : MonoBehaviour
{
    [SerializeField] private VehicleManager vehicleManager;
    public float currentSpeed;

    private bool breaking;

    private void Update()
    {
        this.transform.position = this.transform.position + (this.transform.forward * currentSpeed * Time.deltaTime);
    }

    public void Accelerate(float input)
    {
        if (input == 0 && currentSpeed > 0)
        {
            currentSpeed -= vehicleManager._VehicleStats.Drag * Time.deltaTime;
        }
        else
        {
            currentSpeed += vehicleManager._VehicleStats.Acceleration * Time.deltaTime * input;
            currentSpeed = Mathf.Clamp(currentSpeed, -vehicleManager._VehicleStats.MaxSpeed, vehicleManager._VehicleStats.MaxSpeed);
        }
    }

    public void Break(float input)
    {
        currentSpeed -= vehicleManager._VehicleStats.Breaks * Time.deltaTime * input;
        currentSpeed = Mathf.Clamp(currentSpeed, -vehicleManager._VehicleStats.MaxSpeed, vehicleManager._VehicleStats.MaxSpeed);
    }

    public void Straff(float input)
    {

    }

    public void Rotate(float input)
    {
        float angleRotation = input * vehicleManager._VehicleStats.TurnSpeed * Time.deltaTime;
        this.transform.rotation *= Quaternion.AngleAxis(angleRotation, Vector3.up);
    }
}
