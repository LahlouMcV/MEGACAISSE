using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Vehicle"))
        {

        }
    }
}
