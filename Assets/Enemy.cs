using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    public Animator AI;
   
    public float detectionRange = 10;
    public float visionAngle = 120;
    public Weapon weapon;
    public Transform patrolPoint;
    public float patrolRadius = 10;
    static bool detected;

    [HideInInspector]
    public GameObject player;
    [HideInInspector]
    public NavMeshAgent agent;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        player = PlayerControls.GetInstance().gameObject;
        patrolPoint = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
        detected = Vector3.Distance(transform.position, player.transform.position) < detectionRange && Vector3.Angle(transform.forward, player.transform.position - transform.position) < visionAngle / 2;
        
            AI.SetBool("playerDetected", detected);
        
	}

    public void Damage(float damage)
    {
        Destroy(gameObject);
    }
}
