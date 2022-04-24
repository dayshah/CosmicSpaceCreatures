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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Prologue");
        //SceneManager.LoadScene("AlphaLevel");
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

    public void EndGame()
    {
        SceneManager.LoadScene("EndGame");
    }

}
