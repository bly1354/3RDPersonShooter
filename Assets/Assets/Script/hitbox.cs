using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
[System.Serializable]
public class MyFloatEvent : UnityEvent<float>
{
}

public class hitbox : MonoBehaviour
{
    public MyFloatEvent onHit;

// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
