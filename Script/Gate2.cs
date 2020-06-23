using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate2 : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame

    void Update()
    {
        print(GameObject.FindGameObjectsWithTag("Enemy2").Length);

        if (GameObject.FindGameObjectsWithTag("Enemy2").Length == 0) { Destroy(gameObject); }

    }
}
