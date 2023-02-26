using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CountdownTime : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textDisplay;
    [SerializeField] private int Countdown = 100;
    [SerializeField] private string nextScene;
    private float currentTime;
    //public bool takingAway = false;
    void Start()
    {
        currentTime = Countdown;
    }

    
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        textDisplay.text = "Time  " + currentTime.ToString("0");
        if (currentTime <= 0)
        {
            SceneManager.LoadScene(nextScene);
        }
    }

   
}
