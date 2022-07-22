using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InstrumentScript : MonoBehaviour
{
    [SerializeField] Transform VehicleTrans;
    [SerializeField] GameObject textfieldAssiette;
    [SerializeField] GameObject IconeAssiette;
    [SerializeField] GameObject textfieldAltitude;  

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textfieldAssiette.GetComponent<TMP_Text>().text = Mathf.Round(VehicleTrans.rotation.eulerAngles.z).ToString() + "°";
        IconeAssiette.GetComponent<RectTransform>().localRotation = Quaternion.Euler(new Vector3(0, 0, VehicleTrans.rotation.eulerAngles.z));
        textfieldAltitude.GetComponent<TMP_Text>().text = Mathf.Round(VehicleTrans.position.y).ToString() + " m";
    }
}
