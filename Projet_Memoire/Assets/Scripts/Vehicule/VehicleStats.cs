using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Vehicle Stats", menuName = "Metrics/Vehicle Stats")]
[System.Serializable]
public class VehicleStats : ScriptableObject
{
    //All these stats are multipliers
    //Actual stats of the vehicle are defined by the control module of the board
    [Header("General Stats")]
    public float MaxSpeed;
    public float Drag;
    public float TurnSpeed;
    public float StraffingDistance;
    public float Acceleration;
    public float Breaks;
}