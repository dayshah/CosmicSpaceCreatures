using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameValues : MonoBehaviour
{
    public static string currentLevelName;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name != "PauseMenu") {
            currentLevelName = SceneManager.GetActiveScene().name;
        }

    }
}
