using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UI_Stats : MonoBehaviour
{
    public GameObject levelName_UI;
    public GameObject timeRemaining_UI;
    public GameObject collectionProgress_UI;
    private TMP_Text levelName;
    private TMP_Text timeRemaining;
    private TMP_Text collectionProgress;
    // Start is called before the first frame update
    void Awake(){
        levelName = levelName_UI.GetComponent<TextMeshProUGUI>();
        timeRemaining = timeRemaining_UI.GetComponent<TextMeshProUGUI>();
        collectionProgress = collectionProgress_UI.GetComponent<TextMeshProUGUI>();
    }
    void Start()
    {
        levelName.text = SceneManager.GetActiveScene().name;
        timeRemaining.text = "Time Remaining: 60 seconds";
        collectionProgress.text = "Collection Progress: 100";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
