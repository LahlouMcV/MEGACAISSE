using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] float endScale;
    [SerializeField] float TimeOfExplosion;

    float x;

    private void Start()
    {
        x = endScale - this.transform.localScale.x;
        x /= TimeOfExplosion;
        Invoke("Despawn", TimeOfExplosion);
    }

    private void Update()
    {
        this.transform.localScale += Vector3.one * x * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Obstacle"))
        {
            Destroy(other.gameObject);
        }
    }

    private void Despawn()
    {
        Destroy(this.gameObject);
    }
}
