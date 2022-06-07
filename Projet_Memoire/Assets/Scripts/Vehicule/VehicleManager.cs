using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleManager : MonoBehaviour
{
    public VehicleStats _VehicleStats;
    public VehicleMovement _VehicleMovement;
    public VehicleGravity _VehicleGravity;

    public float HealthPoints = 100f;

    public void HurtVehicle(float amount)
    {
        HealthPoints -= amount;
    }
}
