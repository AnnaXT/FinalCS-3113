using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Scene1 : MonoBehaviour
{
    public float timeRemaining = 0;
    public bool timeIsRunning = true;
    public TMP_Text timeText;
    public static Scene1 Anna2;
    public TMP_Text inputField;

    public string time;
    void Start()
    {
        timeIsRunning = true;
        timeRemaining = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (timeIsRunning)
        {
            if (timeRemaining >= 0)
            {
                timeRemaining += Time.deltaTime;
                DisplayTime(timeRemaining);
            }
        }
        
    }
    void DisplayTime (float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt (timeToDisplay / 60);
        float seconds = Mathf.FloorToInt (timeToDisplay % 60);
        timeText.text = string.Format ("{0:00} : {1:00}", minutes, seconds);
        time = timeText.text;
    }
    //
    

    private void Awake()
    {
        
        if (Anna2 == null)
        {
            Anna2 = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
        
     }
    // public void reset()
    // {
    //     timeRemaining = 0;
    //     DisplayTime(timeRemaining);
    // }

    
    // public void SetName()
    // {
    //     time = inputField.text;

    // }

}
