using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour
{
    public float ForwardSpeed = 5;
    public float SidwaysSpeed = 3;
    public float rotationSpeed = 1;
    public Animator anim;
    public Weapon weapon;
    public List<Weapon> myWeapons = new List<Weapon>();
    public GameObject turnOnLight;

    public float maxHealth = 100;
  
    private float currentHealth;

    private static PlayerControls Instance;
    private Rigidbody rb;
    private int index;

    private void Awake()
    {
        turnOnLight.SetActive(true);

        if (Instance)
        {
            Destroy(Instance.gameObject);
        }
        Instance = this;
    }

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        currentHealth = maxHealth;
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
        SwitchWeapon();
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

    void SwitchWeapon()
    {
        if(Input.GetButtonDown("Fire2") && !weapon.reloading)
        {
            weapon.gameObject.SetActive(false);
            index = (index + 1) % myWeapons.Count;
            weapon = myWeapons[index];
            weapon.gameObject.SetActive(true);
        }
    }

    public void Damage(Vector3 damage)
    {
        currentHealth -= damage.magnitude;
        
        if (currentHealth <= 0)
        {
        

            SceneManager.LoadScene(0);

        }
    }
}

