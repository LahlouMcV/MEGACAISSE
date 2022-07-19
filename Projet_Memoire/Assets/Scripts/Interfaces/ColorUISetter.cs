using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class ColorUISetter : MonoBehaviour
{
    float timer = 0;
    TMP_Text texte;
    // Start is called before the first frame update
    void Start()
    {
        texte = GetComponent<TMP_Text>();
    }

    public void FeedBack()
    {
        if (timer < Time.time)
        {
            timer = Time.time + 0.25f;
            Sq1();
        }
    }
    public void Sq1()
    {
        texte.DOColor(new Color(255, 0, 0), 0.1f);
        Invoke("Sq2", 0.25f);
    }
    public void Sq2()
    {
        texte.DOColor(new Color(255, 255, 255), 0.1f);
    }
}
