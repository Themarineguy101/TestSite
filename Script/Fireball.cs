using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Fireball : MonoBehaviour
{

    public int index;
    public int index1;
    public string levelName;
    public string levelName1;
    int destroyTime = 5;
    public AudioClip audio;
    public AudioMixerGroup audioMixer;
    public GameObject sound;
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
        if (player.name == "player2") { 
            //loading level with build index
            SceneManager.LoadScene(index1);

            //Loading level with scene name
            //SceneManager.LoadScene("levelName1");

            //Restart lvl
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    //to avoid projectile clutter
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter(Collision coll)
    {
        // Collided with a player?
        if (coll.gameObject.tag == "Player")
        {
            //Kill player
            //Destroy(coll.gameObject);
            //victory(gameObject);
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
}
