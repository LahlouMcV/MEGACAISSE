using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Shake : MonoBehaviour
{
    private Transform _SelfTransform;
    [SerializeField] private CameraLook _SelfLook;

    void Start()
    {
        _SelfTransform = transform;
        //_SelfLook = GetComponent<CameraLook>();
        StartCoroutine(Shake(2, 0.5f));
    }

    IEnumerator Shake (float duration, float magnitude) 
    {
        Debug.Log("SHAKE");

        _SelfLook.enabled = false;

        float elapse = 0.0f;

        while (elapse < duration) 
        {
            Vector3 originalPos = _SelfTransform.localPosition;
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            _SelfTransform.localPosition = new Vector3(originalPos.x+x, originalPos.y+y, originalPos.z);
            elapse += Time.deltaTime;

            yield return null;
        }

        _SelfLook.enabled = true;
    }
}
