using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_FocusOnSpeed : MonoBehaviour
{
    //Ce script a pour objectif d'augmenter le FOV de la cam�ra en fonction de la vitesse du joueur

    [SerializeField] private float _MaxFovAdded; //L'ajout maximal de FOV que l'on ajoute par rapport au FOV initiale

    private float _InitFOV; //FOV initiale
    private float _MaxFOV; //FOV maximal que l'on peut atteindre

    private float _CurrentFOV; //FOV que l'on cherche a appliquer

    private Camera _Cam; //R�f�rence vers la camera main
    private VehicleManager _VehiculeManager; //R�f�rence vers le vehiculeManager

    void Start()
    {
        _Cam = Camera.main;
        _VehiculeManager = FindObjectOfType<VehicleManager>();

        _InitFOV = _Cam.fieldOfView;
        _MaxFOV = _InitFOV+ _MaxFovAdded;
        _CurrentFOV = _InitFOV;
    }

    void Update()
    {
        _CurrentFOV = Mathf.Lerp(_InitFOV, _MaxFOV, SpeedRation());
        _Cam.fieldOfView = _CurrentFOV;
    }

    //Renvois 0 si le v�hicule est � l'arr�t, renvois 1 quand le v�hicule est � vitesse max
    private float SpeedRation() 
    {
        float ratio = _VehiculeManager._VehicleMovement.currentSpeed / _VehiculeManager._VehicleStats.MaxSpeed;
        return ratio;
    }

}
