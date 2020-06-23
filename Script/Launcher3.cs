using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class Launcher3 : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        // Collided with a phasing Projectile?
        if (other.gameObject.tag == "Penetration")
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Projectile")
        {
            Destroy(gameObject);
        }

    }
    private static Timer PowerupTimer;
    private int newPower;
    public Rigidbody Power1;
    public Rigidbody Power2;
    public Rigidbody Power3;
    public Rigidbody Power4;
    float Y = 0.82f;
    public float secondsBetweenSpawn = 15;
    public int projectilespeed;
    public float elapsedTime = 0.0f;
    Vector3 Startpos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //random powerup
        newPower = Random.Range(0, 3);
        elapsedTime += Time.deltaTime;
        if (GameObject.FindGameObjectsWithTag("Enemy2").Length == 0)
        {

            if (elapsedTime > secondsBetweenSpawn)
            {
                elapsedTime = 0;
                Debug.Log("Timer works");

                Vector3 spawnPosition = new Vector3(4.71f, 0.72f, 0f);

                switch (newPower)
                {
                    case 0:
                        Rigidbody instantiatedProjectile = Instantiate(Power1,
                                                                   transform.GetChild(1).position,
                                                                   transform.rotation)
                        as Rigidbody;

                        instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, projectilespeed));
                        Debug.Log("Projectile spawns");
                        break;
                    case 1:
                        Rigidbody instantiatedProjectile1 = Instantiate(Power2,
                                                                   transform.GetChild(1).position,
                                                                   transform.rotation)
                        as Rigidbody;

                        instantiatedProjectile1.velocity = transform.TransformDirection(new Vector3(0, 0, 0));
                        Debug.Log("Projectile spawns");
                        break;
                    case 2:
                        Rigidbody instantiatedProjectile2 = Instantiate(Power3,
                                                                   transform.GetChild(1).position,
                                                                   transform.rotation)
                        as Rigidbody;

                        instantiatedProjectile2.velocity = transform.TransformDirection(new Vector3(0, 0, projectilespeed));
                        Debug.Log("Projectile spawns");
                        break;
                    case 3:
                        Rigidbody instantiatedProjectile3 = Instantiate(Power4,
                                                                   transform.GetChild(1).position,
                                                                   transform.rotation)
                        as Rigidbody;

                        instantiatedProjectile3.velocity = transform.TransformDirection(new Vector3(0, 0, projectilespeed));
                        Debug.Log("Projectile spawns");
                        break;
                }
                secondsBetweenSpawn = Random.Range(5, 20);
            }
        }
    }
}
