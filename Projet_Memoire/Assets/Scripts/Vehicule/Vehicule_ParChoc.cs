using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicule_ParChoc : MonoBehaviour
{
    //Ce script a pour objectif de générer un par choc physique pour le véhicule

    [SerializeField] private GameObject _SpringPrefab; //Prefab que l'on va instancier

    [SerializeField] private Vector3 _ReactorPosition = new Vector3(0,5.3f,0); //Position initial du reacteur
    [SerializeField] private Vector3 _SpringLocalPosition = new Vector3(-3.55f,6.472774f,43.7776f); // Position initial du point central de l'elastique
    private Transform _ReactorTransform = null; //Contient le transform du reacteur

    [SerializeField] Transform _SelfTransform; //Contient le transform du vehicule

    void Start()
    {
        _SelfTransform = transform;
        SpawnParChoc();
    }
    void LateUpdate()
    {
        //ReactorOrientation();
    }

    //Fonction permettant de faire spawn le par choc
    private void SpawnParChoc() 
    {
        Transform currentSpringPrefab = Instantiate(_SpringPrefab, _ReactorPosition, Quaternion.identity).transform;

        Transform springTransform = currentSpringPrefab.GetChild(1);
        springTransform.parent = transform;
        springTransform.localPosition = _SpringLocalPosition;

        _ReactorTransform = currentSpringPrefab.GetChild(0);
        _ReactorTransform.parent = null;
        _ReactorTransform.position = _ReactorPosition;
    }
    //Fonction permettant d'orienter le reacteur en fonction de l'orientation du véhicul
    private void ReactorOrientation()
    {
        //_ReactorTransform.forward = _SelfTransform.forward;
        //_ReactorTransform.eulerAngles = new Vector3(270, 180, 0);
        _ReactorTransform.up = _SelfTransform.forward;
    }
}