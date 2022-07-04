using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicule_ParChoc : MonoBehaviour
{
    //Ce script a pour objectif de générer un par choc physique pour le véhicule

    [SerializeField] private GameObject _ParChocPrefab; //Prefab que l'on va instancier

    [SerializeField] private Vector3 _ParChocPosition;
    [SerializeField] private Vector3 _ConnecticPosition;

    Transform _CurrentConnecticTransform;

    Transform _SelfTransform;

    void Start()
    {
        _SelfTransform = transform;
        SpawnParChoc();
    }
    private void LateUpdate()
    {
        PositionConnectic();
    }

    //Fonction permettant de faire spawn le par choc
    private void SpawnParChoc() 
    {
        Vector3 _VehiculePosition = transform.position;
        Transform parChocPrefabTransform = Instantiate(_ParChocPrefab, _VehiculePosition + _ParChocPosition, Quaternion.identity).transform;

        _CurrentConnecticTransform = parChocPrefabTransform.GetChild(2);
        //_CurrentConnecticTransform.SetParent(transform);
        //_CurrentConnecticTransform.position = _VehiculePosition + _ConnecticPosition;
    }

    private void PositionConnectic() 
    {
        _CurrentConnecticTransform.position = _SelfTransform.position + _ConnecticPosition;
    }
}