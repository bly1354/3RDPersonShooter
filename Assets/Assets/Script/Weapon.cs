using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace old
{

public class Weapon : MonoBehaviour {

    public GameObject projectile;
    public float projectileVelocity = 10;
    public Transform spawnPoint;
    public float force = 5;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Shoot();
	}

    void Shoot()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            GameObject spawnedProjectile = Instantiate(projectile, spawnPoint.position, spawnPoint.rotation);
            spawnedProjectile.GetComponent<Projectile>().AddForce(force);

            Destroy(spawnedProjectile, 5f);

        }
    }
}
}
