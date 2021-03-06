using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Vehicle Stats", menuName = "Metrics/Vehicle Stats")]
[System.Serializable]
public class VehicleStats : ScriptableObject
{
    //All these stats are multipliers
    //Actual stats of the vehicle are defined by the control module of the board
    [Header("Mouvement")]
    public float MaxSpeed;
    public float Breaks;
    public float TurnSpeed;
    public float StraffingDistance;
    public float Acceleration;

    [Header("Weapon")]
    public float AimSensitivity;
    public float RateOfFire;
    public float WeaponRange;

    [Header("Physics")]
    public float Drag;
    public float Gravity;
    public float FreefallGravity;
    public float TerminalVelocity;
    public float FloatForce;
    public float FloatHeight;

    [Header("Damage")]
    public float DamageWhenWallCollision;
    public float FallDamage;
}
