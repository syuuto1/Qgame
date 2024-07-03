using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    [SerializeField] int countdownMinutes = 3;
    private float countdownSeconds;
    private Text timeText;


    void Start()
    {
        timeText = GetComponent<Text>();
        countdownSeconds = countdownMinutes * 60 + 1;
    }

    void Update()
    {
        countdownSeconds -= Time.deltaTime;
        var span = new TimeSpan(0, 0, (int)countdownSeconds);
        timeText.text = span.ToString(@"mm\:ss");

        if (countdownSeconds <= 0)
        {
            SceneManager.LoadScene("Clear");
        }
    }
}