using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMovement : MonoBehaviour
{
    [SerializeField] private VehicleManager vehicleManager;
    public float currentSpeed;
    public float currentMaxSpeed;

    private bool breaking;
    private bool accelerate;

    public Vector3 DirectionVector;



    //Update position based on the current speed of the vehicle
    private void FixedUpdate()
    {
        this.transform.position += (DirectionVector.normalized * currentSpeed * Time.deltaTime);
        if(currentSpeed == 0)
        {
            DirectionVector = Vector3.zero;
        }
        float x = currentSpeed / vehicleManager._VehicleStats.MaxSpeed;
        vehicleManager._VehicleSoundFeedback.SetMotorParam(x);
    }

    //Function that accelerates the vehicle
    //If the input is 0 and the speed is greater than 0, the vehicle slows down depending on the drag stat
    public void Accelerate(float input)
    {
        if (input == 0 && currentSpeed > 0 && accelerate == false)
        {
            currentSpeed -= vehicleManager._VehicleStats.Drag * Time.deltaTime;
        }
        else if (input != 0 && breaking == false)
        {
            DirectionVector = input * this.transform.forward;
            ChangeMaxSpeed(input);
            currentSpeed += vehicleManager._VehicleStats.Acceleration * Time.deltaTime * input;
            currentSpeed = Mathf.Clamp(currentSpeed, -currentMaxSpeed, currentMaxSpeed);
            accelerate = true;
        }

        if (input == 0)
        {
            accelerate = false;
        }
    }

    //Function that pulls the breaks of the vehicle
    //If the input is 0 and the speed is negative, the vehicle slows down depending on the drag stat
    public void Break(float input)
    {
        if(input == 0 && currentSpeed < 0 && accelerate == false && breaking == false)
        {
            currentSpeed += vehicleManager._VehicleStats.Drag * Time.deltaTime;
        }
        else if (input != 0 && (accelerate == false || accelerate == true))
        {
            DirectionVector = input * this.transform.forward;
            ChangeMaxSpeed(input);
            currentSpeed -= vehicleManager._VehicleStats.Breaks * Time.deltaTime * input;
            currentSpeed = Mathf.Clamp(currentSpeed, -currentMaxSpeed, currentMaxSpeed);
            breaking = true;
        }
        if (input == 0)
        {
            breaking = false;
        }
    }

    public void Straff(float input)
    {
        if(input != 0)
        {
            DirectionVector += Mathf.Abs(input) * this.transform.right;
            ChangeMaxSpeed(input);
            currentSpeed += input * vehicleManager._VehicleStats.Acceleration * Time.fixedDeltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, -currentMaxSpeed, currentMaxSpeed);
        }
    }

    //Function that rotates the vehicle around the up axis
    public void Rotate(float input)
    {
        float angleRotation = input * vehicleManager._VehicleStats.TurnSpeed * Time.fixedDeltaTime;
        this.transform.rotation *= Quaternion.AngleAxis(angleRotation, Vector3.up);
    }

    public void ChangeMaxSpeed(float input)
    {
        currentMaxSpeed = vehicleManager._VehicleStats.MaxSpeed * input;
    }
}
