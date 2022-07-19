using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class MoverUI : MonoBehaviour
{
    Vector3 startPos;
    float timer = 0;
    TweenCallback Mycallbaque;

    void Start()
    {
        Mycallbaque += Reinit;
        startPos = GetComponent<RectTransform>().localPosition;
    }

    public void ShakeIt()
    {
        Debug.Log("mescouilles");
        if (timer < Time.time)
        {
            timer = Time.time + 0.22f;
            
            GetComponent<RectTransform>().DOShakePosition(0.2f, 0.5f, 10, 90, false, true).OnComplete(Mycallbaque);
        }
    }

    public void Reinit()
    {
        GetComponent<RectTransform>().localPosition = startPos;
    }
}
