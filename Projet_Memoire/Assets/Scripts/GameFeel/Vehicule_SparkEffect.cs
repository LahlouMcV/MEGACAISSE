using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicule_SparkEffect : MonoBehaviour
{
    //Ce script a pour objectif de générer des effet de particule lorsque le véhicule est percuté

    [SerializeField] private ParticleSystem _LeftParticleSystem;
    [SerializeField] private ParticleSystem _RightParticleSystem;


    public void InvokeLeftSpark() 
    {
        _LeftParticleSystem.Play();
    }

    public void InvokeRightSpark()
    {
        _RightParticleSystem.Play();
    }
}
