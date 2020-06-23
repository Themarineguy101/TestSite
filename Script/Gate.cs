using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
        
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    void Update()
    {
        print(GameObject.FindGameObjectsWithTag("Enemy1").Length);

        if (GameObject.FindGameObjectsWithTag("Enemy1").Length == 0) { Destroy(gameObject); }

    }
}
