using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicule_SparkEffect : MonoBehaviour
{
    //Ce script a pour objectif de générer des effet de particule lorsque le véhicule est percuté

    [SerializeField] private GameObject _ParticulePrefab;

    [SerializeField] private Vector3 _LocalPosition = Vector3.zero;
    [SerializeField] private Vector3 _LocalRotation = Vector3.zero;

    private Transform _SelfTransform;

    private void Start()
    {
        _SelfTransform = transform;
    }


    public void InvokeSpark() 
    {
        Debug.Log("Spark !");

        Vector3 newPosition = _LocalPosition + _SelfTransform.position;
        Transform instantiatedParticle = Instantiate(_ParticulePrefab, newPosition, Quaternion.Euler(_LocalRotation.x, _LocalRotation.y, _LocalRotation.z)).transform;

        instantiatedParticle.parent = _SelfTransform;
    }
}
