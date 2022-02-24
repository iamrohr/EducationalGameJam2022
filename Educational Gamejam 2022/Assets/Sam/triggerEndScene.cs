using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class triggerEndScene : MonoBehaviour
{
   

    void Start()
    {
        
    }

    void Update()
    {
        if (GameObject.FindGameObjectWithTag("EndGame") == null) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
