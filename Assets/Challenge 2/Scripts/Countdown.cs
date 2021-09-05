using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    float totalTime;
    float passedTime;
    bool isRunning = false;
    bool isStarted = false;

    public float TotalTime
    {
        set
        {
            if (!isRunning)
            {
                totalTime = value;
            }
        }
    }

    public bool IsFinished
    {
        get
        {
            return isStarted && !isRunning;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            passedTime += Time.deltaTime;
            if (passedTime >= totalTime)
            {
                isRunning = false;
            }
        }
    }

    /// <summary>
    /// Starting the countdown
    /// </summary>
    public void StartCd()
    {
        if (totalTime > 0)
        {
            isRunning = true;
            isStarted = true;
            passedTime = 0;
        }
    }
}
