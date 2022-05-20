using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMovement : MonoBehaviour
{
    [SerializeField] private VehicleManager vehicleManager;
    public float currentSpeed;

    private bool breaking;
    private bool accelerate;

    //Update position based on the current speed of the vehicle
    private void Update()
    {
        this.transform.position = this.transform.position + (this.transform.forward * currentSpeed * Time.deltaTime);
    }

    //Function that accelerates the vehicle
    //If the input is 0 and the speed is greater than 0, the vehicle slows down depending on the drag stat
    public void Accelerate(float input)
    {
        if (input == 0 && currentSpeed > 0)
        {
            currentSpeed -= vehicleManager._VehicleStats.Drag * Time.deltaTime;
        }
        else if (input != 0 && breaking == false)
        {
            currentSpeed += vehicleManager._VehicleStats.Acceleration * Time.deltaTime * input;
            currentSpeed = Mathf.Clamp(currentSpeed, -vehicleManager._VehicleStats.MaxSpeed, vehicleManager._VehicleStats.MaxSpeed);
            accelerate = true;
        }
        else if (input == 0)
        {
            accelerate = false;
        }
    }

    //Function that pulls the breaks of the vehicle
    //If the input is 0 and the speed is negative, the vehicle slows down depending on the drag stat
    public void Break(float input)
    {
        if(input == 0 && currentSpeed < 0 && accelerate == false)
        {
            currentSpeed += vehicleManager._VehicleStats.Drag * Time.deltaTime;
        }
        else if (input != 0)
        {
            currentSpeed -= vehicleManager._VehicleStats.Breaks * Time.deltaTime * input;
            currentSpeed = Mathf.Clamp(currentSpeed, -vehicleManager._VehicleStats.MaxSpeed, vehicleManager._VehicleStats.MaxSpeed);
            breaking = true;
        }
        else if (input == 0)
        {
            breaking = false;
        }
    }

    public void Straff(float input)
    {

    }

    //Function that rotates the vehicle around the up axis
    public void Rotate(float input)
    {
        float angleRotation = input * vehicleManager._VehicleStats.TurnSpeed * Time.deltaTime;
        this.transform.rotation *= Quaternion.AngleAxis(angleRotation, Vector3.up);
    }
}
