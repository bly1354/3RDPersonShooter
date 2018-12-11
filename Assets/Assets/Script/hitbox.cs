using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
[System.Serializable]
public class MyVector3Event : UnityEvent<Vector3>
{
}

public class hitbox : MonoBehaviour
{
    public MyVector3Event onHit;

// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
