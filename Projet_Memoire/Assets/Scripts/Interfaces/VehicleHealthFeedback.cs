using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VehicleHealthFeedback : MonoBehaviour
{
    [SerializeField] VehicleManager _VehicleManager;
    [SerializeField] Image CockpitHealth;
    [SerializeField] Image FrontSideHealth;
    [SerializeField] Image RightSideHealth;
    [SerializeField] Image LeftSideHealth;
    [SerializeField] Image BackSideHealth;

    private void Update()
    {
        CockpitHealth.fillAmount = _VehicleManager.MainHealthPoints / 100;
        FrontSideHealth.fillAmount = _VehicleManager.FrontSideHealth / 25;
        RightSideHealth.fillAmount = _VehicleManager.RightSideHealth / 25;
        LeftSideHealth.fillAmount = _VehicleManager.LeftSideHealth / 25;
        BackSideHealth.fillAmount = _VehicleManager.BackSideHealth / 25;
    }
}
