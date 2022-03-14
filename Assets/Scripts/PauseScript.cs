using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public bool isPaused = true;
    public float _timescale;
    public GameObject PauseMenu;
    void Awake(){
        _timescale = Time.timeScale;
    }
    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.SetActive(false);
        _timescale = Time.timeScale;
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {   
        if (Input.GetKeyUp(KeyCode.P))
        {
            if(isPaused){
                PauseMenu.SetActive(false);
                Time.timeScale = _timescale;
                isPaused = false;
            }else{
                PauseMenu.SetActive(true);
                Time.timeScale = 0;
                isPaused = true;
            }
        }
    }

    public float GetTimeScale(){
        return _timescale;
    }
}
