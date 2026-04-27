using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private TimeSpan raceStart;
    public delegate void TimerEvent();

    private void OnEnable()
    {
        StartGate.StartRace += StartRace;
        FinishGate.FinishRace += FinishRace;
    }
       
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void StartRace()
    {
        
    }

    void FinishRace()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
