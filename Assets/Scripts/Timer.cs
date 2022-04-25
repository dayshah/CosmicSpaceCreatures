using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    private float timerLength = 7f * 60f;
    private float timerRemaining;
    [SerializeField]
    private TextMeshProUGUI tens;
    [SerializeField]
    private TextMeshProUGUI units;
    [SerializeField]
    private TextMeshProUGUI tens_seconds;
    [SerializeField]
    private TextMeshProUGUI units_seconds;
    
    void Start()
    {
        StartTimer();
    }

    
    void Update()
    {
        if (timerRemaining > 0) {
            timerRemaining -= Time.deltaTime;
            UpdateTimer(timerRemaining);
        } else {
            timerRemaining = 0;
            QuitGame();
        }
    }

    private void StartTimer() {
        timerRemaining = timerLength;
    }

    private void UpdateTimer(float time) {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        string remainingTime = string.Format("{00:00}{1:00}", minutes, seconds);
        tens.text = remainingTime[0].ToString();
        units.text = remainingTime[1].ToString();
        tens_seconds.text = remainingTime[2].ToString();
        units_seconds.text = remainingTime[3].ToString();
    }

    private void QuitGame()
    {
        SceneManager.LoadScene("FailScreen");
    }
}
