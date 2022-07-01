using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleManager : MonoBehaviour
{
    [Header("References")]
    public VehicleStats _VehicleStats;
    public VehicleMovement _VehicleMovement;
    public VehicleGravity _VehicleGravity;
    public VehicleSoundFeedback _VehicleSoundFeedback;

    [Header("HealthStats")]
    public float MainHealthPoints = 100f;
    public float RightSideHealth = 25f;
    public float LeftSideHealth = 25f;
    public float FrontSideHealth = 25f;
    public float BackSideHealth = 25f;


    #region Health Management
    public void HurtVehicle(float amount)
    {
        MainHealthPoints -= amount;
    }

    public void HurtAllSides(float amount)
    {
        bool a = false;
        if (LeftSideHealth > 0)
            LeftSideHealth -= amount;
        else if(LeftSideHealth <= 0 && a == false)
        {
            a = true;
            MainHealthPoints -= amount;
        }
        if (RightSideHealth > 0)
            RightSideHealth -= amount;
        else if (RightSideHealth <= 0 && a == false)
        {
            a = true;
            MainHealthPoints -= amount;
        }
        if (FrontSideHealth > 0)
            FrontSideHealth -= amount;
        else if (FrontSideHealth <= 0 && a == false)
        {
            a = true;
            MainHealthPoints -= amount;
        }
        if (BackSideHealth > 0)
            BackSideHealth -= amount;
        else if (BackSideHealth <= 0 && a == false)
        {
            a = true;
            MainHealthPoints -= amount;
        }

    }

    public void HurtSide(float amount, VehicleCollisionManager.HitBoxSide side)
    {
        switch (side)
        {
            case VehicleCollisionManager.HitBoxSide.Left:
                if (LeftSideHealth > 0)
                    LeftSideHealth -= amount;
                else
                    MainHealthPoints -= amount;
                break;
            case VehicleCollisionManager.HitBoxSide.Right:
                if (RightSideHealth > 0)
                    RightSideHealth -= amount;
                else
                    MainHealthPoints -= amount;
                break;
            case VehicleCollisionManager.HitBoxSide.Forward:
                if (FrontSideHealth > 0)
                    FrontSideHealth -= amount;
                else
                    MainHealthPoints -= amount;
                break;
            case VehicleCollisionManager.HitBoxSide.Back:
                if (BackSideHealth > 0)
                    BackSideHealth -= amount;
                else
                    MainHealthPoints -= amount;
                break;
        }
        if(MainHealthPoints <= 0)
        {
            Defeat();
        }
    }
    #endregion

    public void Defeat()
    {
        SceneManager._SceneManager.LoadScene(0);
    }

}
