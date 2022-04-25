using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStarter : MonoBehaviour
{

    [SerializeReference]
    private GameObject htpPanel;
    [SerializeReference]
    private GameObject startPanel;

    public void StartGame()
    {
        SceneManager.LoadScene("Prologue");
        Time.timeScale = 1f;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("AlphaLevel");
        Time.timeScale = 1f;
    }

    public void ControlToggle()
    {
        if (htpPanel.activeSelf)
        {
            startPanel.SetActive(true);
            htpPanel.SetActive(false);
        }
        else
        {
            startPanel.SetActive(false);
            htpPanel.SetActive(true);
        }
    }

    public void ToCredits()
    {
        SceneManager.LoadScene("CreditsAndAttributions");
        Time.timeScale = 1f;
    }

    public void ToStartMenu()
    {
        SceneManager.LoadScene("Start");
        Time.timeScale = 1f;
    }

    public void EndGame()
    {
        SceneManager.LoadScene("EndGame");
    }

}
