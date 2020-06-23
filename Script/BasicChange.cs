using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BasicChange : MonoBehaviour
{
    public int index;
    public string levelName;
    public Button yourButton;

    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick()
    {
        //loading level with build index
        SceneManager.LoadScene(index, LoadSceneMode.Single);

        //Loading level with scene name
        //SceneManager.LoadScene("levelName, LoadSceneMode.Single");

        //Restart lvl
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
