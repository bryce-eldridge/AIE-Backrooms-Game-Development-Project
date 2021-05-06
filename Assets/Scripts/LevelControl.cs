using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour
{

    public int index;
    public string levelName;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Load next scene with the build index
            SceneManager.LoadScene(1);

            //Load next scene with the scene name
            SceneManager.LoadScene(levelName);
        }

    }
}
