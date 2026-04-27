using System;
using UnityEngine;
using static GameManager;
public class FinishGate : MonoBehaviour
{
    public static event TimerEvent FinishRace;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            FinishRace.Invoke();
        }
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
