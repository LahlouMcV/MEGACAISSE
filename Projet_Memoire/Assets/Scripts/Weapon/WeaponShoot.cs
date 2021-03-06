using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShoot : MonoBehaviour
{
    [SerializeField] VehicleManager _VehicleManager;
    [SerializeField] Camera WeaponCamera;
    [SerializeField] GameObject WeaponBullet;
    public FMODUnity.StudioEventEmitter SoundFeedback;
    [SerializeField] ParticleSystem Muzzle1;
    [SerializeField] ParticleSystem Muzzle2;
    RaycastHit hit;
    private bool Shot = true;

    public void ShootWeapon(float input)
    {
        Ray ray = WeaponCamera.ScreenPointToRay(new Vector3(WeaponCamera.pixelWidth / 2, WeaponCamera.pixelHeight / 2));
        
        if (Physics.SphereCast(ray, 2.5f, out hit, Mathf.Infinity, LayerMask.GetMask("Ground", "Obstacle")) && Shot && input != 0)
        {
            Shot = false;
            SoundFeedback.Play();
            Muzzle1.Play();
            Muzzle2.Play();
            //Spawn Shot Feedback
            Invoke("SpawnExplosion", 0.25f);
            Invoke("Reload", _VehicleManager._VehicleStats.RateOfFire);
        }
    }

    private void SpawnExplosion()
    {
        if(hit.point != null)
            Instantiate(WeaponBullet, hit.point, Quaternion.identity);
    }

    private void Reload()
    {
        Muzzle1.Stop();
        Muzzle2.Stop();
        Shot = true;
        hit = new RaycastHit();
    }
}
