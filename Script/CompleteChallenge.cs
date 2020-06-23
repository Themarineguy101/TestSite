using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteChallenge : MonoBehaviour
{
    public int index;
    public string levelName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy1").Length == 0)
        {
            if (GameObject.FindGameObjectsWithTag("Enemy2").Length == 0)
            {
                if (GameObject.FindGameObjectsWithTag("Enemy3").Length == 0)
                {
                    SceneManager.LoadScene(index, LoadSceneMode.Single);
                }
            }
        }
    }
}
