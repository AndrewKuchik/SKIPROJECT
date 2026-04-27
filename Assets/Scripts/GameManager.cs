using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private DateTime raceStart;
    private TimeSpan raceTime;
    private bool racing = false;
    
    public delegate void TimerEvent();

    private void OnEnable()
    {
        StartGate.StartRace += StartRace;
        FinishGate.FinishRace += FinishRace;
    }
       
    void FinishRace()
    {
        racing = false;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void StartRace()
    {
        racing = true;
        raceStart = DateTime.Now;
    }

    

    // Update is called once per frame
    void Update()
    {
        if (racing)
            raceTime = DateTime.Now - raceStart;
        //TimeSpan raceTime = DateTime.Now - raceStart;

    }
}
