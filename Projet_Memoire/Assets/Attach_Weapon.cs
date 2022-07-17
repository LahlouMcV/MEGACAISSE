using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attach_Weapon : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform hand;

      void Awake ()
    {
        transform.SetParent(hand);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
