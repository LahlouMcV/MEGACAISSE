using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VehicleHealthFeedback : MonoBehaviour
{
    [SerializeField] VehicleManager _VehicleManager;
    [SerializeField] TMP_Text CockpitHealth;
    [SerializeField] TMP_Text FrontSideHealth;
    [SerializeField] TMP_Text RightSideHealth;
    [SerializeField] TMP_Text LeftSideHealth;
    [SerializeField] TMP_Text BackSideHealth;

    [SerializeField] Image CockpitPicto;
    [SerializeField] Image FrontSidePicto;
    [SerializeField] Image RightSidePicto;
    [SerializeField] Image LeftSidePicto;
    [SerializeField] Image BackSidePicto;

    private void Update()
    {
        CockpitHealth.text = _VehicleManager.MainHealthPoints.ToString();
        FrontSideHealth.text = _VehicleManager.FrontSideHealth.ToString();
        RightSideHealth.text = _VehicleManager.RightSideHealth.ToString();
        LeftSideHealth.text = _VehicleManager.LeftSideHealth.ToString();
        BackSideHealth.text = _VehicleManager.BackSideHealth.ToString();
    }

    public void collisionInterface(Image img)
    {

    }
}
