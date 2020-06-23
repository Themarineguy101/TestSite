using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Victory : MonoBehaviour
{
    public int index;
    public string levelName;
    public object player;
    // Start is called before the first frame update
    void Start()
    {
    }
    void victory()
    {
        //loading level with build index
        SceneManager.LoadScene(index, LoadSceneMode.Single);

        //Loading level with scene name
        //SceneManager.LoadScene("levelName, LoadSceneMode.Single");

        //Restart lvl
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            victory();
        }
    }
}
