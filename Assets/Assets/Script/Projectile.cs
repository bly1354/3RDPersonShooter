using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddForce(float force)
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * force, ForceMode.Impulse);
    }
}
