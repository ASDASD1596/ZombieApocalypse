using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CountdownTime : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textDisplay;
    [SerializeField] private int Countdown = 100;
    [SerializeField] private string nextScene;
    private float _currentTime;

    void Start()
    {
        _currentTime = Countdown;
    }
    
    void Update()
    {
        _currentTime -= Time.deltaTime;
        textDisplay.text = "Time  " + _currentTime.ToString("0");
        if (_currentTime <= 0)
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
