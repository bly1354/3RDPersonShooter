using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTimer : MonoBehaviour {

    public float killTime = 5;
	// Use this for initialization
	void Start () {
        StartCoroutine("Kill");
	}
	
	IEnumerator Kill()
    {
        yield return new WaitForSeconds(killTime);
        Destroy(this.gameObject);
    }
}
