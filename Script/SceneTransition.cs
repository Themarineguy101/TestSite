using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    public int index;
    public string levelName;
    public Button yourButton;
    public Animator Transition;
    public float TransitionTime = 1f;
    public GameObject loadingScreen;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick()
    {
        //loading level with build index
        StartCoroutine(LoadLevel(index));

        //Loading level with scene name
        //SceneManager.LoadScene("levelName, LoadSceneMode.Single");

        //Restart lvl
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    IEnumerator LoadLevel(int index)
    {
        Transition.SetTrigger("Start");

        yield return new WaitForSeconds(TransitionTime);

        StartCoroutine(Loading(index));
    }
    IEnumerator Loading(int index)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(index, LoadSceneMode.Single);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            Debug.Log(progress);

            slider.value = progress;

            yield return null;
        }
    }
}
