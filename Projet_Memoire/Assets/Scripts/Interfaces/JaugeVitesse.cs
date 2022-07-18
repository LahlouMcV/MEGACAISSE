using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JaugeVitesse : MonoBehaviour
{
    [SerializeField] VehicleManager _VehicleManager;
    [SerializeField] GameObject textfieldSpeed;
    [SerializeField] GameObject JaugeSpeed;
    [SerializeField] float offsetJauge;

    private void Start()
    {
        JaugeSpeed.GetComponent<Image>().fillAmount = offsetJauge;
    }
    void Update()
    {
        textfieldSpeed.GetComponent<TMP_Text>().text = Mathf.Round(_VehicleManager._VehicleMovement.currentSpeed).ToString() + " km/h";
        JaugeSpeed.GetComponent<Image>().fillAmount = (_VehicleManager._VehicleMovement.currentSpeed/ _VehicleManager._VehicleStats.MaxSpeed) + offsetJauge;
    }
}
