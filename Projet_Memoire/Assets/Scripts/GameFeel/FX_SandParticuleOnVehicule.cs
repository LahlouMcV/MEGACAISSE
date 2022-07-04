using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FX_SandParticuleOnVehicule : MonoBehaviour
{
    //Ce script a pour objectif de faire spawn l'effet de sable sur le v�hicule et de lui appliquer un effet en fonction de la vitesse du v�hicule

    [SerializeField] private GameObject _SandEffect; //Contient le FX de sable
    private Transform _CurrentSandEffectTransform; //Contient le transform du sandEffect
    private ParticleSystem _CurrentSandEffectParticule; //Contient le particule system du sandEffect
    private float _CurrentParticuleSpeed; //contient la vitesse actuelle des particules � appliquer

    [SerializeField] private Vector2 _SandDistanceFromVehicule = new Vector2(30,5); //Contient la distance de l'effet de sable par rapport au v�hicule

    [SerializeField] private float _MinParticuleSpeed = 1f; //Contient la vitesse min des particules
    [SerializeField] private float _MaxParticuleSpeed = 8f; //Contient la vitesse max des particules

    private Transform _SelfTransform; //R�f�rence vers le transform de l'objet

    private VehicleManager _VehiculeManager; //R�f�rence vers le vehiculeManager

    void Start()
    {
        _SelfTransform = transform;
        _VehiculeManager = FindObjectOfType<VehicleManager>();
        SpawnAndRegisterSandEffect();
    }
    void LateUpdate()
    {
        _CurrentParticuleSpeed = Mathf.Lerp(_MinParticuleSpeed, _MaxParticuleSpeed, SpeedRation());
        var main = _CurrentSandEffectParticule.main;
        main.simulationSpeed = _CurrentParticuleSpeed;
        
        SetSandEffectPosition();
    }

    //Fonction permettant de spawn l'effet de particule de sable et de l'enregistrer
    private void SpawnAndRegisterSandEffect()
    {
        _CurrentSandEffectTransform = Instantiate(_SandEffect, _SelfTransform.position, Quaternion.identity).transform;
        _CurrentSandEffectParticule = _CurrentSandEffectTransform.GetComponent<ParticleSystem>();
    }
    //Fonction permettant de positionner l'effet de sable par rapport au v�hicule
    private void SetSandEffectPosition() 
    {
        _CurrentSandEffectTransform.position = _SelfTransform.position + (_SandDistanceFromVehicule.x * _SelfTransform.forward) + (_SandDistanceFromVehicule.y * Vector3.up);
        _CurrentSandEffectTransform.LookAt(_SelfTransform);
    }

    //Renvois 0 si le v�hicule est � l'arr�t, renvois 1 quand le v�hicule est � vitesse max
    private float SpeedRation()
    {
        float ratio = _VehiculeManager._VehicleMovement.currentSpeed / _VehiculeManager._VehicleStats.MaxSpeed;
        return ratio;
    }
}
