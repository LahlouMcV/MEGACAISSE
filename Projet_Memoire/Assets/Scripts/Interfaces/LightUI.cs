using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class LightUI : MonoBehaviour
{
    MeshRenderer meshRender;
    Light lum;
    float timer = 0;

    void Start()
    {
        meshRender = GetComponent<MeshRenderer>();
        lum = GetComponentInChildren<Light>();
    }

    public void Alert()
    {
        if (timer < Time.time)
        {
            timer = Time.time + 0.35f;
            Sq1();
        }
    }

    public void Sq1()
    {
        meshRender.material.DOFloat(1, "_LightOn", 0.05f);
        lum.DOIntensity(1, 0.05f);
        Invoke("Sq2", 0.05f);
    }
    public void Sq2()
    {
        meshRender.material.DOFloat(0, "_LightOn", 0.05f);
        lum.DOIntensity(0, 0.05f);
        Invoke("Sq3", 0.05f);
    }
    public void Sq3()
    {
        meshRender.material.DOFloat(1, "_LightOn", 0.05f);
        lum.DOIntensity(1, 0.05f);
        Invoke("Sq4", 0.05f);
    }
    public void Sq4()
    {
        meshRender.material.DOFloat(0, "_LightOn", 0.05f);
        lum.DOIntensity(0, 0.05f);
        Invoke("Sq5", 0.05f);
    }
    public void Sq5()
    {
        meshRender.material.DOFloat(1, "_LightOn", 0.15f);
        lum.DOIntensity(1, 0.15f);
        Invoke("Init", 0.15f);
    }

    public void Init()
    {
        meshRender.material.DOFloat(0, "_LightOn", 0.1f);
        lum.DOIntensity(0, 0.1f);
    }
}
