using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrepareScene : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        start();
    }
    void start()
    {
        //Restart lvl
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
