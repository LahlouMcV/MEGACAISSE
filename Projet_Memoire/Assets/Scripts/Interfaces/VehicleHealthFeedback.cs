using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class VehicleHealthFeedback : MonoBehaviour
{
    [SerializeField] VehicleManager _VehicleManager;
    [SerializeField] GameObject CockpitHealth;
    [SerializeField] GameObject FrontSideHealth;
    [SerializeField] GameObject RightSideHealth;
    [SerializeField] GameObject LeftSideHealth;
    [SerializeField] GameObject BackSideHealth;

    [SerializeField] GameObject CockpitPicto;
    [SerializeField] GameObject FrontSidePicto;
    [SerializeField] GameObject RightSidePicto;
    [SerializeField] GameObject LeftSidePicto;
    [SerializeField] GameObject BackSidePicto;

    [SerializeField] GameObject FrontIndicator;
    [SerializeField] GameObject RightIndicator;
    [SerializeField] GameObject LeftIndicator;
    [SerializeField] GameObject BackIndicator;

    private void Update()
    {
        CockpitHealth.GetComponent<TMP_Text>().text = _VehicleManager.MainHealthPoints.ToString();
        FrontSideHealth.GetComponent<TMP_Text>().text = _VehicleManager.FrontSideHealth.ToString();
        RightSideHealth.GetComponent<TMP_Text>().text = _VehicleManager.RightSideHealth.ToString();
        LeftSideHealth.GetComponent<TMP_Text>().text = _VehicleManager.LeftSideHealth.ToString();
        BackSideHealth.GetComponent<TMP_Text>().text = _VehicleManager.BackSideHealth.ToString();
    }

    public void CollisionInterfaceFront()
    {
        FrontIndicator.GetComponent<LightUI>().Alert();
        FrontSidePicto.GetComponent<MoverUI>().ShakeIt();
        FrontSideHealth.GetComponent<MoverUI>().ShakeIt();
        FrontSideHealth.GetComponent<ColorUISetter>().FeedBack();
    }
    public void CollisionInterfaceRight()
    {
        RightIndicator.GetComponent<LightUI>().Alert();
        RightSidePicto.GetComponent<MoverUI>().ShakeIt();
        RightSideHealth.GetComponent<MoverUI>().ShakeIt();
        RightSideHealth.GetComponent<ColorUISetter>().FeedBack();
    }
    public void CollisionInterfaceLeft()
    {
        LeftIndicator.GetComponent<LightUI>().Alert();
        LeftSidePicto.GetComponent<MoverUI>().ShakeIt();
        LeftSideHealth.GetComponent<MoverUI>().ShakeIt();
        LeftSideHealth.GetComponent<ColorUISetter>().FeedBack();
    }
    public void CollisionInterfaceBack()
    {
        BackIndicator.GetComponent<LightUI>().Alert();
        BackSidePicto.GetComponent<MoverUI>().ShakeIt();
        BackSideHealth.GetComponent<MoverUI>().ShakeIt();
        BackSideHealth.GetComponent<ColorUISetter>().FeedBack();
    }
    public void CollisionInterfaceCockpit()
    {
        CockpitPicto.GetComponent<MoverUI>().ShakeIt();
        CockpitHealth.GetComponent<MoverUI>().ShakeIt();
        CockpitHealth.GetComponent<ColorUISetter>().FeedBack();
    }


}
