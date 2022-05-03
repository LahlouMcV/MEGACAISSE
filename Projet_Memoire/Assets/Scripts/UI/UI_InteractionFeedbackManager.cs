using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_InteractionFeedbackManager : MonoBehaviour
{
    [Header("Refs")]
    [SerializeField] private GameObject Borders;
    [SerializeField] private GameObject Cursor;

    public void LaunchInteractionMode()
    {
        Borders.SetActive(true);
        Cursor.SetActive(false);
    }

    public void StopInteractionMode()
    {
        Borders.SetActive(false);
        Cursor.SetActive(true);
    }
}
