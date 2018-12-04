using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float ForwardSpeed = 5;
    public float SidwaysSpeed = 3;
    public float rotationSpeed = 1;
    public Animator anim;
    public Weapon weapon;

    private static PlayerControls Instance;
    private Rigidbody rb;

    private void Awake()
    {
        if (Instance)
        {
            Destroy(Instance.gameObject);
        }
        Instance = this;
    }

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
      
	}
	
    public static PlayerControls GetInstance()
    {
        return Instance;
    }
	// Update is called once per frame
	void Update () {
        Move();
        Rotate();
        shoot();
	}

    private void Move()
    {
        Vector3 forward = Input.GetAxis("Vertical") * ForwardSpeed * transform.forward;
        Vector3 sideways = Input.GetAxis("Horizontal") * SidwaysSpeed * transform.right;
        //transform.position += (forward + sideways) * Time.deltaTime;
        Vector3 moveDir = forward + sideways;
        anim.SetFloat("DirectionX", Vector3.Dot(moveDir.normalized, transform.right));
        anim.SetFloat("DirectionY", Vector3.Dot(moveDir.normalized, transform.forward));
        rb.AddForce(forward + sideways);
    }
        
    void Rotate()
    {
        Vector3 lookAtPoint = transform.position + transform.forward;
        //Rotate
        lookAtPoint += Input.GetAxis("Mouse X") * rotationSpeed * transform.right * Time.deltaTime;
        transform.LookAt  (lookAtPoint);
    }

    void shoot()
    {
        if(Input.GetButton("Fire1"))
        {
            weapon.Fire();
        }
        else
        {
            weapon.StopFiring();
        }
    }
}

