using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class PowerSpawner : MonoBehaviour
{
    private static Timer PowerupTimer;
    private int newPower;
    public GameObject Power1;
    public GameObject Power2;
    public GameObject Power3;
    public GameObject Power4;
    float Y = 0.82f;
    public float secondsBetweenSpawn = 15;
    public float elapsedTime = 0.0f;
    Vector3 Startpos;
    // Use this for initialization
    void Start()
    {
        //randomize timer to int between 15000 and 45000
        //double powerupInterval = Random.Range(15000, 45000);
        //double powerupInterval = 2000;
        //create timer
        //PowerupTimer = new Timer(powerupInterval);
        //create the event for the timer
        //PowerupTimer.Elapsed += new ElapsedEventHandler(CreateNewPowerup);
        //start timer
        //PowerupTimer.Start();
        //Make sure timer resets
        //PowerupTimer.AutoReset = true;
    }

    // Update is called once per frame
    void Update()
    {
        //random powerup
        newPower = Random.Range(0,3);
        Startpos = new Vector3(Random.Range(-24f, 24f), Y, Random.Range(-24f, 24f));
        elapsedTime += Time.deltaTime;
        
        if (elapsedTime > secondsBetweenSpawn)
        {
            elapsedTime = 0;
            Debug.Log("Timer works");

            Vector3 spawnPosition = new Vector3(4.71f, 0.72f, 0f);

            switch (newPower)
            {
                case 0:
                    Instantiate(Power1, Startpos, Quaternion.identity);
                    Debug.Log("Power-up spawns");
                    break;
                case 1:
                    Instantiate(Power2, Startpos, Quaternion.identity);
                    Debug.Log("Power-up spawns");
                    break;
                case 2:
                    Instantiate(Power3, Startpos, Quaternion.identity);
                    Debug.Log("Power-up spawns");
                    break;
                case 3:
                    Instantiate(Power4, Startpos, Quaternion.identity);
                    Debug.Log("Power-up spawns");
                    break;
            }
            secondsBetweenSpawn = Random.Range(10, 25);
        }
    }

    void CreateNewPowerup(object source, ElapsedEventArgs e)
    {
        //Debug.Log("Timer works");
        //newPower = Random.Range(0, 2);
        //create new powerup
        //Startpos = new Vector3(Random.Range(-24f, 24f), Y, Random.Range(-24f, 24f));
        if (newPower == 0)
        {
            Instantiate(Power1, Startpos, Quaternion.identity);
            Debug.Log("Power-up spawns");
        }
        if (newPower == 1)
        {
            Instantiate(Power2, Startpos, Quaternion.identity);
            Debug.Log("Power-up spawns");
        }
        if (newPower == 2)
        {
            Instantiate(Power3, Startpos, Quaternion.identity);
            Debug.Log("Power-up spawns");
        }
        switch (newPower)
        {
            case 0:
                Instantiate(Power1, Startpos, Quaternion.identity);
                Debug.Log("Power-up spawns");
                break;
            case 1:
                Instantiate(Power2, Startpos, Quaternion.identity);
                Debug.Log("Power-up spawns");
                break;
            case 2:
                Instantiate(Power3, Startpos, Quaternion.identity);
                Debug.Log("Power-up spawns");
                break;
        }
    }
}

