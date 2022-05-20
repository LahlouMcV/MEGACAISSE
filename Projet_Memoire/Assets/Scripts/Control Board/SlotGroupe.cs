using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SlotGroupe
{
    [Header("Turning Function")]
    public Slot TurnRight;
    public Slot TurnLeft;

    [Header("Speed Function")]
    public Slot Accelerate;
    public Slot Break;

    [Header("Straffing Function")]
    public Slot StraffLeft;
    public Slot StraffRight;
}
