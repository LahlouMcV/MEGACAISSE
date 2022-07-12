using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicule_Vrombissement : MonoBehaviour
{
    [SerializeField] private float _Magnitude = 0.01f;
    private Transform _SelfTransform;
    private bool _CanVrombr = true;

    void Start()
    {
        _SelfTransform = transform;
    }

    void Update()
    {
        if (_CanVrombr)
        {
            Vector3 originalPos = _SelfTransform.position;

            float x = Random.Range(-1f, 1f) * _Magnitude;
            float y = Random.Range(-1f, 1f) * _Magnitude;

            _SelfTransform.position = new Vector3(originalPos.x + x, originalPos.y, originalPos.z+y);
        }
    }

    public void Shake(float magnitude) 
    {
        StartCoroutine(Shake(0.4f, magnitude));
    }
    public IEnumerator Shake(float duration, float magnitude) 
    {
        Debug.Log("SHAKE");
        Vector3 initPosition = _SelfTransform.position;
        float elapse = 0.0f;
        _CanVrombr = false;

        while (elapse < duration)
        {
            Vector3 lastPosition = _SelfTransform.localPosition;
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            _SelfTransform.localPosition = new Vector3(lastPosition.x + x, lastPosition.y + y, lastPosition.z);
            elapse += Time.deltaTime;

            yield return null;
        }

        _SelfTransform.position = initPosition;
        _CanVrombr = true;
    }
}
