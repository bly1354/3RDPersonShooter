using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalRotation : MonoBehaviour {

    public Transform player;
    public float rotationSpeed = 1;
    public float angleLimit = 40;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Rotate();
	}

    void Rotate()
    {
        Vector3 lookAtPoint = transform.position + transform.forward;
        //Rotate
        Vector3 delta = Input.GetAxis("Mouse Y") * rotationSpeed * transform.up * Time.deltaTime;
        if (Vector3.Dot((transform.forward + delta).normalized, player.forward) > Mathf.Cos(angleLimit * Mathf.Deg2Rad ))
        {
            lookAtPoint += delta;
        }
        transform.LookAt(lookAtPoint);
    }
}
