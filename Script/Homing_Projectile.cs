using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Homing_Projectile : MonoBehaviour
{

    public int index;
    public int index1;
    public string levelName;
    public string levelName1;
    int destroyTime = 5;
    public AudioClip audio;
    public Transform target;
    public GameObject target1;
    public Rigidbody rigidBody;
    public float rotationSpeed;
    public float speed;
    public GameObject sound;
    void FixedUpdate()
    {
        //Vector2 direction = (Vector2)target.position - rigidBody.position;
        //direction.Normalize();
        //float rotateAmount = Vector3.Cross(direction, transform.up).z;
        //rigidBody.angularVelocity = -angleChangingSpeed * rotateAmount;
        //rigidBody.velocity = transform.up * movementSpeed;
    }
    // Start is called before the first frame update
    void Start()
    {

    }
    void victory(Object player)
    {
        if (player.name == "player1")
        {
            //loading level with build index
            SceneManager.LoadScene(index, LoadSceneMode.Single);

            //Loading level with scene name
            //SceneManager.LoadScene("levelName, LoadSceneMode.Single");

            //Restart lvl
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (player.name == "player2")
        {
            //loading level with build index
            SceneManager.LoadScene(index1);

            //Loading level with scene name
            //SceneManager.LoadScene("levelName1");

            //Restart lvl
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    // Update is called once per frame
    void Update()
    {
        target1 = FindClosestByTag("Player");
        target = target1.transform;
        Vector3 targetDirection = target.position - transform.position;

        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, rotationSpeed * Time.deltaTime, 0.0F);

        transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.Self);
        
            transform.rotation = Quaternion.LookRotation(newDirection);
        
    }

    void OnCollisionEnter(Collision coll)
    {
        // Collided with a player?
        if (coll.gameObject.tag == "Player")
        {
            //Kill player
            //Destroy(coll.gameObject);
            victory(gameObject);
        }
        //destroy fireball
        //AudioSource.PlayClipAtPoint(audio, this.gameObject.transform.position, 10f);

        GameObject sound1 = Instantiate(sound,
                                                       transform.position,
                                                       transform.rotation)
            as GameObject;
        Destroy(gameObject);
    }
    void Die()
    {
        Destroy(gameObject);
    }
    GameObject FindClosestByTag(string tag)
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag(tag);
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
}
