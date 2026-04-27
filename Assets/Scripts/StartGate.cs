using System;
using UnityEngine;
using static GameManager;
public class StartGate : MonoBehaviour

{       
    public static event TimerEvent StartRace;

    private void OnTriggerEnter(Collider other)
    {
        throw new NotImplementedException();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
