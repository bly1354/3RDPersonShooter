using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RaycastWeaponData : WeaponData
{
    public float range;
    public GameObject trail;
    public GameObject Hitparticle;
    public GameObject enemy;
    
}


public class RaycastWeapon : Weapon {

    public RaycastWeaponData raycastData;

    protected override void Start()
    {
        data = raycastData;
        base.Start();
    }

    protected override void LaunchProjectile()
    {
        base.LaunchProjectile();
        RaycastHit hit;
        GameObject bulletTrail = Instantiate(raycastData.trail, raycastData.muzzle.position, Quaternion.LookRotation(raycastData.muzzle.forward));
      
        if (Physics.Raycast(raycastData.muzzle.position, raycastData.muzzle.transform.forward, out hit, raycastData.range, ~raycastData.myPlayerLayer))
        {
            bulletTrail.transform.localScale = new Vector3(1, 1, (hit.point - raycastData.muzzle.position).magnitude);
            Debug.DrawRay(raycastData.muzzle.position, raycastData.muzzle.forward * hit.distance, Color.red);
            Debug.Log("Did Hit");
            Instantiate(raycastData.Hitparticle, hit.point, Quaternion.identity);

            if(hit.collider.gameObject.GetComponent<hitbox>())
            {
                hit.collider.gameObject.GetComponent<hitbox>().onHit.Invoke(data.damage * raycastData.muzzle.transform.forward);
            }
        }
       
        else
        {
            bulletTrail.transform.localScale = new Vector3(1, 1, raycastData.range);
        }
    }
}

