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

    [SerializeField] GameObject CockpitPictoJauge;
    [SerializeField] GameObject FrontSidePictoJauge;
    [SerializeField] GameObject RightSidePictoJauge;
    [SerializeField] GameObject LeftSidePictoJauge;
    [SerializeField] GameObject BackSidePictoJauge;

    [SerializeField] GameObject FrontIndicator;
    [SerializeField] GameObject RightIndicator;
    [SerializeField] GameObject LeftIndicator;
    [SerializeField] GameObject BackIndicator;

    float MainHealthPointsMax=0;
    float FrontSideHealthMax=0;
    float RightSideHealthMax=0;
    float LeftSideHealthMax=0;
    float BackSideHealthMax=0;

    private void Start()
    {
        MainHealthPointsMax =_VehicleManager.MainHealthPoints;
        FrontSideHealthMax = _VehicleManager.FrontSideHealth;
        RightSideHealthMax = _VehicleManager.RightSideHealth;
        LeftSideHealthMax = _VehicleManager.LeftSideHealth;
        BackSideHealthMax = _VehicleManager.BackSideHealth;
    }

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
        SetColorPicto(FrontSidePictoJauge, FrontSideHealthMax, _VehicleManager.FrontSideHealth);
    }
    public void CollisionInterfaceRight()
    {
        RightIndicator.GetComponent<LightUI>().Alert();
        RightSidePicto.GetComponent<MoverUI>().ShakeIt();
        RightSideHealth.GetComponent<MoverUI>().ShakeIt();
        RightSideHealth.GetComponent<ColorUISetter>().FeedBack();
        SetColorPicto(RightSidePictoJauge, RightSideHealthMax, _VehicleManager.RightSideHealth);
    }
    public void CollisionInterfaceLeft()
    {
        LeftIndicator.GetComponent<LightUI>().Alert();
        LeftSidePicto.GetComponent<MoverUI>().ShakeIt();
        LeftSideHealth.GetComponent<MoverUI>().ShakeIt();
        LeftSideHealth.GetComponent<ColorUISetter>().FeedBack();
        SetColorPicto(LeftSidePictoJauge, LeftSideHealthMax, _VehicleManager.LeftSideHealth);
    }
    public void CollisionInterfaceBack()
    {
        BackIndicator.GetComponent<LightUI>().Alert();
        BackSidePicto.GetComponent<MoverUI>().ShakeIt();
        BackSideHealth.GetComponent<MoverUI>().ShakeIt();
        BackSideHealth.GetComponent<ColorUISetter>().FeedBack();
        SetColorPicto(BackSidePictoJauge, BackSideHealthMax, _VehicleManager.BackSideHealth);
    }
    public void CollisionInterfaceCockpit()
    {
        CockpitPicto.GetComponent<MoverUI>().ShakeIt();
        CockpitHealth.GetComponent<MoverUI>().ShakeIt();
        CockpitHealth.GetComponent<ColorUISetter>().FeedBack();
        SetColorPicto(CockpitPictoJauge, MainHealthPointsMax, _VehicleManager.MainHealthPoints);
    }

    public void SetColorPicto(GameObject picto, float vieMax, float vieActuelle)
    {
        Image img = picto.GetComponent<Image>();
        img.fillAmount = 1 - (vieActuelle/ vieMax);
        Debug.Log(img + (1 - (vieActuelle / vieMax)).ToString());
    }
}
