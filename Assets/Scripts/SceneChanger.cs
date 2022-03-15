using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    public PauseScript pauseScript;
    void Update()
    {
    }
    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void ToHubLevel()
    {
        if (SceneManager.GetActiveScene().name != "Title"){
        Time.timeScale = pauseScript._timescale;
        }
        SceneManager.LoadScene("MainScene");
    }
    public void RestartScene()
    {
        if (SceneManager.GetActiveScene().name != "Title"){
        Time.timeScale = pauseScript._timescale;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
