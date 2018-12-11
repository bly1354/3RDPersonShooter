using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    //AI Varibles
    public Animator AI;
   
    public float detectionRange = 10;
    public float visionAngle = 120;
    public Weapon weapon;
    public Transform patrolPoint;
    public float patrolRadius = 10;
    static bool detected;
    static List<Enemy> canSee = new List<Enemy>();
    [HideInInspector]
    public GameObject player;
    [HideInInspector]
    public NavMeshAgent agent;


    //Health Varibles
    public float maxHealth = 100;
    public GameObject healthBar;
    private float currentHealth;

    //Animation
    public Animator anim;
    private Vector3 lastPos;

	// Use this for initialization
	void Start () {
        currentHealth = maxHealth;
        agent = GetComponent<NavMeshAgent>();
        player = PlayerControls.GetInstance().gameObject;
        patrolPoint = this.transform;
        lastPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        bool detected = Vector3.Distance(transform.position, player.transform.position) < detectionRange && Vector3.Angle(transform.forward, player.transform.position - transform.position) < visionAngle / 2;

        Move();

        if(detected)
        {
            if(!canSee.Contains(this))
            {
                canSee.Add(this);
            }
            else
            {
                canSee.Remove(this);
            }
        }
            AI.SetBool("playerDetected", detected);


        
	}

    public void Damage(Vector3 damage)
    {
        currentHealth -= damage.magnitude;
        healthBar.transform.localScale = new Vector3(currentHealth / maxHealth, 1, 1);
        if (currentHealth <= 0)
        {
        canSee.Remove(this);
        Destroy(gameObject);

        }
    }

    private void Move()
    {
        Vector3 moveDir = transform.position - lastPos ;
        anim.SetFloat("DirectionX", Vector3.Dot(moveDir.normalized, transform.right));
        anim.SetFloat("DirectionY", Vector3.Dot(moveDir.normalized, transform.forward));
        lastPos = transform.position;
    }
}
