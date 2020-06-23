using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public int index;
    public string levelName;
    public float Speed = 5f;
    public float JumpHeight = 2f;
    public float GroundDistance = 0.2f;
    //public float DashDistance = 5f;
    public LayerMask Ground;
    public Rigidbody projectile;
    public float projectilespeed = 20;
    public float fireRate;
    private AudioSource source;
    bool LastReminder = true;
    int delay = 1;
    public GameObject lightindicator;
    public Transform Player;

    private Rigidbody _body;
    private Vector3 _inputs = Vector3.zero;
    private bool _isGrounded = true;
    private Transform _groundChecker;
    private float lastShot;

    // Start is called before the first frame update
    void Start()
    {
        _body = GetComponent<Rigidbody>();
        source = GetComponent<AudioSource>();
        _groundChecker = transform.GetChild(0);
    }

    void Update()
    {
        //_isGrounded = Physics.CheckSphere(_groundChecker.position, GroundDistance, Ground, QueryTriggerInteraction.Ignore);

        //takes movement input
        _inputs = Vector3.zero;
        _inputs.x = Input.GetAxis("Horizontal");
        _inputs.z = Input.GetAxis("Vertical");
        if (_inputs != Vector3.zero)
            transform.forward = _inputs;
        //Code to activate jump
        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _body.AddForce(Vector3.up * Mathf.Sqrt(JumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
        }
        //Code to activate dash
        //if (Input.GetButtonDown("Dash"))
        //{
        //    Vector3 dashVelocity = Vector3.Scale(transform.forward, DashDistance * new Vector3((Mathf.Log(1f / (Time.deltaTime * _body.drag + 1)) / -Time.deltaTime), 0, (Mathf.Log(1f / (Time.deltaTime * _body.drag + 1)) / -Time.deltaTime)));
        //    _body.AddForce(dashVelocity, ForceMode.VelocityChange);
        //}
        if (Input.GetButtonDown("Fire1"))
        {
            if (Time.time > fireRate + lastShot)
            {
                Rigidbody instantiatedProjectile = Instantiate(projectile,
                                                           transform.GetChild(1).position,
                                                           transform.rotation)
                as Rigidbody;

                instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, projectilespeed));
                lastShot = Time.time;
                LastReminder = false;
            }
            
        }
        //tells user fireball is avalible
        if (Time.time > fireRate + lastShot && LastReminder == false)
        {
            GameObject light = Instantiate(lightindicator,
                                                       transform.position,
                                                       transform.rotation)
            as GameObject;

            light.transform.parent = Player;
            LastReminder = true;
            Destroy(light, delay);
        }
        //kills the player if he/she falls off
        if (gameObject.transform.position.y < -1)
        {
            Destroy(gameObject);
            victory();
        }
    }
    //kills the player if leaves the screen
    void OnBecameInvisible()
    {
        Destroy(gameObject);
        victory();
    }


    void FixedUpdate()
    {
        //Controls movement
        _body.MovePosition(_body.position + _inputs * Speed * Time.fixedDeltaTime);
    }

    void victory()
    {
        //loading level with build index
        SceneManager.LoadScene(index);

        //Loading level with scene name
        //SceneManager.LoadScene("levelName");

        //Restart lvl
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
