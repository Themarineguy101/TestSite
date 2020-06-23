using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoloPlayer : MonoBehaviour
{
    public int index;
    public string levelName;
    public int index1;
    public string levelName1;
    public int index2;
    public string levelName2;
    public float Speed = 5f;
    public float JumpHeight = 2f;
    public float GroundDistance = 0.2f;
    //public float DashDistance = 5f;
    public LayerMask Ground;
    public Rigidbody projectile;
    public Rigidbody Homing;
    public Rigidbody Phased;
    public Rigidbody Bounce;
    public Rigidbody Hidden;
    public float projectilespeed = 20;
    public float Homingspeed = 15;
    public float fireRate;
    private AudioSource source;
    bool LastReminder = true;
    bool Shield1 = false;
    Object light2 = null;
    Object light3 = null;
    float delay = 0.5f;
    public GameObject lightindicator;
    public GameObject shieldindicator;
    public GameObject PhasedShotIndicator;
    public Transform Player;
    int HomingShots = 0;
    int PhasedShots = 0;
    int HiddenShots = 0;
    int BounceShots = 0;

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
    private void OnTriggerEnter(Collider other)
    {
        // Collided with a phasing Projectile?
        if (other.gameObject.tag == "Penetration")
        {
            victory();
        }
    }
    void OnCollisionEnter(Collision coll)
    {
        // Collided with a shield powerup?
        if (coll.gameObject.tag == "Shield")
        {
            Shield1 = true;
        }
        // Collided with a homing powerup?
        if (coll.gameObject.tag == "Homing")
        {
            HomingShots = HomingShots + 1;
        }
        // Collided with a Phasing powerup?
        if (coll.gameObject.tag == "Phased")
        {
            PhasedShots = PhasedShots + 1;
        }
        // Collided with a Hidden powerup?
        if (coll.gameObject.tag == "Hidden")
        {
            HiddenShots = HiddenShots + 1;
        }
        // Collided with a Bounce powerup?
        if (coll.gameObject.tag == "Bounce")
        {
            BounceShots = BounceShots + 1;
        }// Collided with a Projectile?
        if (coll.gameObject.tag == "Projectile")
        {
            if (Shield1 == true)
            {
                Shield1 = false;
                Destroy(light2);
                Speed = 5f;
            }
            else
            {
                victory();
            }
        }
    }
    void Update()
    {
        //_isGrounded = Physics.CheckSphere(_groundChecker.position, GroundDistance, Ground, QueryTriggerInteraction.Ignore);

        //takes movement input
        _inputs = Vector3.zero;
        _inputs.x = Input.GetAxis("Horizontal");
        _inputs.z = Input.GetAxis("Vertical");
        if (_inputs != Vector3.zero)
        {
            transform.forward = _inputs;
        }
        //Code to activate jump
        //if (Input.GetButtonDown("Jump") && _isGrounded)
        //{
        //    _body.AddForce(Vector3.up * Mathf.Sqrt(JumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
        //}
        //Code to activate dash
        //if (Input.GetButtonDown("Dash"))
        //{
        //    Vector3 dashVelocity = Vector3.Scale(transform.forward, DashDistance * new Vector3((Mathf.Log(1f / (Time.deltaTime * _body.drag + 1)) / -Time.deltaTime), 0, (Mathf.Log(1f / (Time.deltaTime * _body.drag + 1)) / -Time.deltaTime)));
        //    _body.AddForce(dashVelocity, ForceMode.VelocityChange);
        //}
        if (Input.GetButtonDown("Fire"))
        {
            if (Time.time > fireRate + lastShot)
            {
                if (PhasedShots > 0)
                {
                    Rigidbody instantiatedProjectile = Instantiate(Phased,
                                                               transform.GetChild(1).position,
                                                               transform.rotation)
                    as Rigidbody;

                    instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, projectilespeed - 2));
                    PhasedShots = PhasedShots - 1;
                }
                else if (HomingShots > 0)
                {
                    Rigidbody instantiatedProjectile = Instantiate(Homing,
                                                               transform.GetChild(1).position,
                                                               transform.rotation)
                    as Rigidbody;

                    instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0));
                    HomingShots = HomingShots - 1;
                }
                else if (BounceShots > 0)
                {
                    Rigidbody instantiatedProjectile = Instantiate(Bounce,
                                                               transform.GetChild(1).position,
                                                               transform.rotation)
                    as Rigidbody;

                    instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, projectilespeed - 2));
                    BounceShots = BounceShots - 1;
                }
                else if (HiddenShots > 0)
                {
                    Rigidbody instantiatedProjectile = Instantiate(Hidden,
                                                               transform.GetChild(1).position,
                                                               transform.rotation)
                    as Rigidbody;

                    instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, projectilespeed - 2));
                    HiddenShots = HiddenShots - 1;
                }
                else
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

        //light2.transform.parent = Player;
        if (Shield1 == true)
        {
            GameObject light2 = Instantiate(shieldindicator,
                                                       transform.position,
                                                       transform.rotation)
            as GameObject;

            light2.transform.parent = Player;
            Speed = 4f;
            Destroy(light2, delay);
        }
        if (PhasedShots > 0)
        {
            GameObject light3 = Instantiate(PhasedShotIndicator,
                                                       transform.position,
                                                       transform.rotation)
            as GameObject;

            light3.transform.parent = Player;
            Destroy(light3, delay);

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

        //Kill player
        Destroy(gameObject);
        //loading level with build index
        if (GameObject.FindGameObjectsWithTag("Enemy2").Length == 0)
        {
            SceneManager.LoadScene(index, LoadSceneMode.Single);
        }
        else if (GameObject.FindGameObjectsWithTag("Enemy1").Length == 0)
        {
            SceneManager.LoadScene(index1, LoadSceneMode.Single);
        }
        else
        {
            SceneManager.LoadScene(index2, LoadSceneMode.Single);
        }

        //Loading level with scene name
        //SceneManager.LoadScene("levelName, LoadSceneMode.Single");

        //Restart lvl
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
